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
        /// <summary>
        /// Get All Hotels
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var hotels = await _hotelServices.GetAllHotels();
            return Ok(hotels);
        }
        /// <summary>
        /// Get Hotel By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{id}")]
        public Task<IActionResult> GetHotelByID(int id)
        {
            Hotel hotel = await _hotelServices.GetHotelByID(id);
            if (hotel != null)
            {
                return Ok(hotel);
            }
            return NotFound();
        }
        /// <summary>
        /// Get Hotel By Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{name}")]
        public async Task<IActionResult> GetHotelByName(string name)
        {
            List<Hotel> hotels = await _hotelServices.GetHotelByName(name);
            if (hotels?.Count > 0)
            {
                return Ok(hotels);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("[action]/{id}/{name}")]//bunun erine Url den almak daha doğru olacaktır.
        public async Task<IActionResult> GetHotelByIdAndName(int id, string name)
        {
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Hotel hotel)
        {

            Hotel hotelNew = await _hotelServices.CreateHotel(hotel);
            return CreatedAtAction("Get", new { id = hotelNew.Id }, hotelNew);// Burada, header da Location alanında eklenen datanın get metoduyla çağırılacağı endpoint paylaşılır.

            #region sınıfın başında [ApiController] attribute u olduğu için bunu kullanmamıza gerek yok.
            //if (ModelState.IsValid)
            //{
            //    Hotel hotelNew = _hotelServices.CreateHotel(hotel);
            //    return CreatedAtAction("Get", new { id = hotelNew.Id }, hotelNew);// Burada, header da Location alanında eklenen datanın get metoduyla çağırılacağı endpoint paylaşılır.
            //}
            //return BadRequest(ModelState); // 400 + validation errors 
            #endregion
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Hotel hotel)
        {
            if (_hotelServices.GetHotelByID(hotel.Id) != null)
            {
                return Ok(_hotelServices.UpdateHotel(hotel));
            }
            return NotFound();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_hotelServices.GetHotelByID(id) != null)
            {
                await _hotelServices.DeleteHotel(id);
                return Ok();
            }
            return NotFound();
        }
    }
}
