using Domain.Dtos;
using Domain.Entities;

namespace Domain.Services;

public interface ITravelRouteService
{
    Task InsertAsync(RequestInsertTravelRouteDto dto);
    Task UpdateAsync(int id, TravelRoute route);
    Task<IEnumerable<TravelRoute>> FindAllAsync();
    Task<TravelRoute> FindByIdAsync(int id);
    Task Delete(int id);
    Task<ResponseGetTravelDto> GetTravel(RequestTravelDto dto);
}
