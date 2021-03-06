using HotelNoSql.Interfaces;
using HotelNoSql.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelNoSql.Data
{
    public class MongoDbClient : IMongoDbClient
    {

        private readonly IMongoCollection<Guest> _guests;
       // private readonly IMongoCollection<GuestPhonenumber> _guestPhonenumbers;
        private readonly IMongoCollection<Room> _rooms;
        private readonly IMongoCollection<Reservation> _reservations;

        public MongoDbClient(IConfiguration configuration )
        {
            var client = new MongoClient(configuration.GetSection("MongoDb").GetSection("ConnectionString").Value);
            var db = client.GetDatabase(configuration.GetSection("MongoDb").GetSection("DatabaseName").Value);
            _guests = db.GetCollection<Guest>(configuration.GetSection("MongoDb").GetSection("GuestsCollectionName").Value);
            _rooms = db.GetCollection<Room>(configuration.GetSection("MongoDb").GetSection("RoomsCollectionName").Value);
            _reservations = db.GetCollection<Reservation>(configuration.GetSection("MongoDb").GetSection("ReservationsCollectionName").Value);
        }

        

        public IMongoCollection<Guest> GuestCollection()
        {
            return _guests;
        }
       
        public IMongoCollection<Room> RoomsCollection()
        {
            return _rooms;
        }

        public IMongoCollection<Reservation> ReservationsCollection()
        {
            return _reservations;
        }

    }
}
