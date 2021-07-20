using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace HotelNoSql.Models
{
    public class Room
    {
        [BsonId]
        
        public int Id { get; set; }

       public string RoomTypeName { get; set; }
       
        public decimal Price { get; set; }

        


        //public string ReservationId { get; set; }
    
            

       
    }
}
