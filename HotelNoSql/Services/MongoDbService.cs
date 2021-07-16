using HotelNoSql.Interfaces;
using HotelNoSql.Models;
using MongoDB.Driver;
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

       
        public List<Reservation> GetReservations()
        {
            return _reservations.Find(reservation => true).ToList();
        }
        public List<ReservationView> GetFullReservations()
        {
            List<Reservation> resList=_reservations.Find(reservation => true).ToList();
            
            List<ReservationView> reservationsList= new List<ReservationView>();
           
            foreach (var item in resList)
            {
                ReservationView view  = new ReservationView();
                view.Guest = _guests.Find(guest => guest.Id == item.GuestId).FirstOrDefault();
                view.Room = _rooms.Find(room => room.Id == item.RoomId).FirstOrDefault();
                view.ReservationId = item.Id;
                view.CheckInDate = item.CheckInDate;
                view.CheckOutDate = item.CheckOutDate;
                reservationsList.Add(view);
            }
        return reservationsList; 
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
