using HotelNoSql.Interfaces;
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
    public class RoomsController : ControllerBase
    {

        public readonly IHotel _hotel;

        public RoomsController(IHotel hotel)
        {
            _hotel = hotel;
        }



        [HttpGet]
        public IActionResult GetRooms()
        {
            return new OkObjectResult(_hotel.GetRooms());
        }

        [HttpGet("GetFreeRooms")]
        public IActionResult GetFreeRooms()
        {
            return new OkObjectResult(_hotel.GetFreeRooms());
        }

        
       
    }
}
