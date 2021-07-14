using HotelNoSql.Interfaces;
using HotelNoSql.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelNoSql.Services
{
    public class MongoDbService: IHotel
    {
        private readonly IMongoCollection<Guest> _guests;
       


        public MongoDbService(IMongoDbClient client)
        {
            _guests = client.GuestCollection();
        }
       
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

       
    }
}
