using Domain.Dtos;
using Domain.Entities;

namespace Domain.Repositories;

public interface ITravelRouteRepository
{
    Task InsertAsync(TravelRoute route);
    Task UpdateAsync(TravelRoute route);
    Task<IEnumerable<TravelRoute>> FindAllAsync();
    Task<TravelRoute> FindByIdAsync(int id);
    Task DeleteAsync(TravelRoute route);
    Task<IEnumerable<TravelRoute>> FindByDestination(string destination);
    Task<IEnumerable<TravelRoute>> FindByOrigin(string origin);
}
