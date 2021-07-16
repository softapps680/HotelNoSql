using HotelNoSql.Interfaces;
using HotelNoSql.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelNoSql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        public readonly IHotel _hotel;

        public ReservationsController(IHotel hotel)
        {
            _hotel = hotel;
        }
        [HttpGet]
        public IActionResult GetReservations()
        {
            return new OkObjectResult(_hotel.GetReservations());
        }
        [HttpPost]
        public IActionResult PostReservation(ReservationCreate res)
        {

            Reservation reservation = new Reservation
            {
                GuestId=res.GuestId,
                RoomId=res.RoomId,
                CheckInDate=res.CheckInDate,
                CheckOutDate=res.CheckOutDate
            };

            _hotel.PostReservation(reservation);

            return new CreatedAtRouteResult("GetGuest", new { id = reservation.Id }, reservation);

        }
        [HttpGet("GetFullReservations")]
        public IActionResult GetFullReservations()
        {
            return new OkObjectResult(_hotel.GetFullReservations());
        }
    }
}

        

        
  