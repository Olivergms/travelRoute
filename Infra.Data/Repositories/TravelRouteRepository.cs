using Domain.Dtos;
using Domain.Entities;
using Domain.Repositories;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories;

public class TravelRouteRepository : ITravelRouteRepository
{
    private readonly ApplicationContext _db;

    public TravelRouteRepository(ApplicationContext context) => _db = context;

    public async Task DeleteAsync(TravelRoute route)
    {      
        _db.TravelRoutes.Remove(route);
        _db.SaveChanges();
    }

    public async Task<IEnumerable<TravelRoute>> FindAllAsync()
    {
        return await _db.TravelRoutes.AsNoTracking().ToListAsync();
    }

    public async Task<IEnumerable<TravelRoute>> FindByDestination(string destination)
    {
        return await _db.TravelRoutes.Where(x => x.Destination.Equals(destination.ToUpper())).ToListAsync();
    }

    public async Task<TravelRoute> FindByIdAsync(int id)
    {
        return await _db.TravelRoutes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<TravelRoute>> FindByOrigin(string origin)
    {
        return await _db.TravelRoutes.Where(x => x.Origin.Equals(origin.ToUpper())).ToListAsync();
    }

    public async Task InsertAsync(TravelRoute route)
    {
        await _db.TravelRoutes.AddAsync(route);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateAsync(TravelRoute route)
    {
        var dbRoute = await _db.TravelRoutes.FindAsync(route.Id);
        if (dbRoute == null) throw new Exception("Rota não encontrada");

        _db.Entry(dbRoute).CurrentValues.SetValues(route);
        _db.SaveChanges();
        
    }
}
