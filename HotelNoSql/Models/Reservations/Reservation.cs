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

        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string GuestId { get; set; }

        public int RoomId { get; set; }

        public DateTime CheckInDate { get; set;}
        public DateTime CheckOutDate { get; set; }

        // public String GuestId{ get; set; }
        // public int RoomId { get; set; }
        // public int PaymentMethodId { get; set; }

        /* public Guest Guest { get; set; }
         public Room Room { get; set; }
         public PaymentMethod PaymentMethod { get; set; }*/
    }
}
