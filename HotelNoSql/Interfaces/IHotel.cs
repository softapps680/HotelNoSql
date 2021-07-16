using HotelNoSql.Controllers;
using HotelNoSql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelNoSql.Interfaces
{
    public interface IHotel
    {
        #region Guest
        Guest PostGuest(Guest guest);
        Guest GetGuest(string id);
        List<Guest> GetGuests();
        Guest PutGuest(Guest guest);

        void DeleteGuest(string id);
        #endregion

        List<Room> GetRooms();
       List<Reservation> GetReservations();

        List<ReservationView> GetFullReservations();
        void PostReservation(Reservation res);
    }
}
