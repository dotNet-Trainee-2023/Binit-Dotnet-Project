using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class PlaceService : IPlaceService
    {
        private readonly ApiDBContext _dBContext;

        public PlaceService(ApiDBContext dBContext)
        {
            _dBContext = dBContext;
        }
        public async Task<Place> Create(Place place)
        {
            if (place == null)
            {
                throw new ArgumentNullException();
            }
            await _dBContext.Places.AddAsync(place);
            await _dBContext.SaveChangesAsync();

            return place;
        }

        public async Task<Place> Delete(Place place)
        {
            _dBContext.Places.Remove(place);
            await _dBContext.SaveChangesAsync();
            return place; 
        }

        public async Task<List<Place>> GetAllPlaces()
        {
            return await _dBContext.Places.ToListAsync();
        }

        public async Task<Place> GetById(Guid id)
        {
            return await _dBContext.Places.FirstOrDefaultAsync(place => place.Id == id);
        }

        public Task<Place> Update(Place place)
        {
            throw new NotImplementedException();
        }
    }
}
