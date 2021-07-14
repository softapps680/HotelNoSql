using HotelNoSql.Interfaces;
using HotelNoSql.Models;
using HotelNoSql.Services;
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
    public class GuestsController : ControllerBase
    {
        public readonly IHotel _hotel;

        public GuestsController(IHotel hotel)
        {
            _hotel = hotel;
        }

        [HttpPost]
        public IActionResult PostGuest(CreateGuest createGuest)
        {
            Guest guest = new Guest
            {
                FirstName = createGuest.FirstName,
                LastName = createGuest.LastName,
                Email = createGuest.Email
            };

            _hotel.PostGuest(guest);
         return new CreatedAtRouteResult("GetGuest", new { id =guest.Id }, guest);

        }
        [HttpGet("{id}", Name= "GetGuest")]
        public IActionResult GetGuest(string id)
        {
            return new OkObjectResult(_hotel.GetGuest(id));
        }
        
        [HttpGet]
        public IActionResult GetGuests()
        {
            return new OkObjectResult(_hotel.GetGuests());
        }
        [HttpPut]
        public IActionResult PutGuest(Guest guest)
        {
            _hotel.PutGuest(guest);
            return new OkObjectResult(guest);
        }
        
        [HttpDelete("{Id}")]
        public IActionResult DeleteGuest(string id)
        {
            _hotel.DeleteGuest(id);
            return new NoContentResult();
        }
    }
}
