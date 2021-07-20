using HotelNoSql.Interfaces;
using HotelNoSql.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HotelNoSql.Services
{
    public class MongoDbService: IHotel
    {
        private readonly IMongoCollection<Guest> _guests;
        private readonly IMongoCollection<Reservation> _reservations;
        private readonly IMongoCollection<Room> _rooms;

        public MongoDbService(IMongoDbClient client)
        {
            _guests = client.GuestCollection();
            _rooms = client.RoomsCollection(); 
            _reservations = client.ReservationsCollection();
        }

        #region Guest
        public void DeleteGuest(string id)
        {
            _guests.DeleteOne(guest => guest.Id == id);
        }
        public Guest GetGuest(string id)
        {
            return _guests.Find(guest => guest.Id == id).FirstOrDefault();
        }
        public List<Guest> GetGuests()
        {
            return _guests.Find(guest => true).ToList();
        }
        public Guest PostGuest(Guest guest)
        {
            _guests.InsertOne(guest);
            return guest;
        }
        public Guest PutGuest(Guest guest)
        {
            return _guests.FindOneAndReplace(c => c.Id == guest.Id, guest);
        }

        #endregion
        public List<Room> GetRooms()
        {
            return _rooms.Find(room => true).ToList();
        }

        public List<Room> GetFreeRooms()
        {
            List<Room> allRooms = _rooms.Find(room => true).ToList();
           
            //Hämta reservationer mellan arrival och leave
            string arrival = "2021-07-19T23:09:00.000+00:00";
            string leave= "2021-07-22T23:09:00.000+00:00";
            DateTime arrivalDateTime = Convert.ToDateTime(arrival).ToUniversalTime();
            DateTime leaveDateTime = Convert.ToDateTime(leave).ToUniversalTime();

           List<Reservation> reservations = _reservations.Find<Reservation>(x => x.CheckInDate >= arrivalDateTime && x.CheckOutDate <= leaveDateTime).ToList();

            List<Room> reservedRooms = new List<Room>();
            List<Room> allrooms = _rooms.Find(room => true).ToList();
            
            //Vilka rum är bokade då
            foreach (var item in reservations)
            {
                Room reservedRoom = new Room();
                reservedRoom.Id = item.Room.Id;
                reservedRoom.RoomTypeName = item.Room.RoomTypeName;
                reservedRoom.Price = item.Room.Price;
                reservedRooms.Add(reservedRoom);
            }

           var freeRooms = allrooms.Except(reservedRooms, new ObjectComparer()).ToList();
           
           return freeRooms.ToList(); ;
        }

        public List<Reservation> GetReservations()
        {
            return _reservations.Find(reservation => true).ToList();
        }
       

        public void PostReservation(Reservation res)
        {
            _reservations.InsertOne(res);
           
        }
        public Reservation PutReservation(Reservation res)
        {
            return _reservations.FindOneAndReplace(c => c.Id == res.Id, res);
        }

       
    }
}
/*
 If you want to compare sequences of objects of some custom data type, you have to implement the IEquatable<T> generic 
interface in a helper class. And override GetHashCode and Equals methods.*/
public class ObjectComparer : IEqualityComparer<Room>
{
    public int GetHashCode(Room room)
    {
        if (room == null)
        {
            return 0;
        }
        return room.Id.GetHashCode();
    }

    public bool Equals(Room x1, Room x2)
    {
        if (ReferenceEquals(x1, x2))
        {
            return true;
        }
        if (ReferenceEquals(x1, null) ||ReferenceEquals(x2, null))
        {
            return false;
        }
        return x1.Id == x2.Id;
    }
}