using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelNoSql.Models.Reservations
{
    public class PaymentMethod
    {
        [BsonId]

        public int Id { get; set; }

        public string PaymentMethodName { get; set; }
    }
}
