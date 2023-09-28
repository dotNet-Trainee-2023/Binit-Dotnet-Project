using WebAPI.Models;

namespace WebAPI.Services
{
    public interface IPlaceService
    {
        Task<Place> GetById(Guid id);
        Task<List<Place>> GetAllPlaces();
        Task<Place> Create(Place place);
        Task<Place> Update(Place place);
        Task<Place> Delete(Place place);

    }
}
