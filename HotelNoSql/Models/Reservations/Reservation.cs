using HotelNoSql.Models.Reservations;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelNoSql.Models
{
    public class Reservation
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public DateTime CheckInDate { get; set;}
        public DateTime CheckOutDate { get; set; }
        public Room Room { get; set; }
        public Guest Guest { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

    }
}
