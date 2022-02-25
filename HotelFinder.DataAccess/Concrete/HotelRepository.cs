using HotelFinder.DataAccess.Abstract;
using HotelFinder.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.DataAccess.Concrete
{
    public class HotelRepository : IHotelRepository
    {
        public async Task<Hotel> CreateHotel(Hotel hotel)
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                hotelDbContext.Hotels.Add(hotel);
                await hotelDbContext.SaveChangesAsync();
                return hotel;
            }
        }

        public async Task DeleteHotel(int id)
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                var hotel = await GetHotelById(id);
                if (hotel != null)
                {
                    hotelDbContext.Hotels.Remove(hotel);
                    await hotelDbContext.SaveChangesAsync();
                }
            }
        }

        public async Task<List<Hotel>> GetAllHotels()
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                return await hotelDbContext.Hotels.ToListAsync();
            }
        }

        public async Task<Hotel> GetHotelById(int id)
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                return await hotelDbContext.Hotels.FindAsync(id);
            }
        }

        public async Task<List<Hotel>> GetHotelByName(string name)
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                return await hotelDbContext.Hotels.Where(a => a.Name.Contains(name.Trim(' '))).ToListAsync();
            }
        }

        public async Task<Hotel> UpdateHotel(Hotel hotel)
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                hotelDbContext.Update(hotel);
                await hotelDbContext.SaveChangesAsync();
                return hotel;
            }
        }
    }
}
