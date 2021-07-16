using HotelNoSql.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelNoSql.Interfaces
{
    public interface IMongoDbClient
    {
        IMongoCollection<Guest> GuestCollection();
      //  IMongoCollection<GuestPhonenumber> GuestPhoneNumberCollection();
        IMongoCollection<Room> RoomsCollection();
        //  IMongoCollection<RoomType> RoomTypesCollection();
        IMongoCollection<Reservation> ReservationsCollection();
    }
}
