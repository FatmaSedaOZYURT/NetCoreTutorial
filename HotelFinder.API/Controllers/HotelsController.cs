using HotelFinder.Business.Abstract;
using HotelFinder.Business.Concrete;
using HotelFinder.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelFinder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        IHotelService _hotelServices;
        public HotelsController(IHotelService hotelServices)
        {
            _hotelServices = hotelServices;
        }

        [HttpGet]
        public List<Hotel> Get()
        {
            return _hotelServices.GetAllHotels();
        }
        [HttpGet("{id}")]
        public Hotel Get(int id)
        {
            return _hotelServices.GetHotelByID(id);
        }
        [HttpPost]
        public Hotel Post([FromBody]Hotel hotel)
        {
            return _hotelServices.CreateHotel(hotel);
        }
        [HttpPut]
        public Hotel Put([FromBody]Hotel hotel)
        {
            return _hotelServices.UpdateHotel(hotel);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _hotelServices.DeleteHotel(id);
        }
    }
}
