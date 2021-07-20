using HotelNoSql.Models.Reservations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelNoSql.Models
{
    public class ReservationCreate
    {
        

        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public Room Room { get; set; }
        public Guest Guest { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

    }
}
