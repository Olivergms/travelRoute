using Domain.Dtos;
using Domain.Entities;
using Domain.Repositories;
using Domain.Services;
using Services.Utils;

namespace Services.Services;

public class TravelRouteService : ITravelRouteService
{
    private readonly ITravelRouteRepository _routeRepository;

    public TravelRouteService(ITravelRouteRepository routeRepository)
    {
        _routeRepository = routeRepository;
    }

    public async Task<ResponseGetTravelDto> GetTravel(RequestTravelDto dto)
    {
        try
        {
            var origin =  await _routeRepository.FindByOrigin(dto.Origin);
            if (origin.Count() < 1) throw new Exception("Origem não encontrado.");

            var destinationList = await _routeRepository.FindByDestination(dto.Destination);
            if (destinationList.Count() < 1) throw new Exception("Destino não encontrado.");

            var travelRouteList = await _routeRepository.FindAllAsync();
            if (travelRouteList.Count() < 1) throw new Exception("Nenhuma rota encontrada.");


            var result = Dijkstra.FindShortestRoute(travelRouteList.ToList(), dto.Origin, dto.Destination);

            if (result == null) throw new Exception($"Não existe rota de {dto.Origin} até {dto.Destination}");
            return new ResponseGetTravelDto { Cost = result.TotalCost, Route = result.Path };



        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public async Task Delete(int id)
    {
        var routeFromDb = await _routeRepository.FindByIdAsync(id);

        if (routeFromDb == null) throw new Exception("Rota não encontrada");

        await _routeRepository.DeleteAsync(routeFromDb);
    }

    public async Task<IEnumerable<TravelRoute>> FindAllAsync()
    {
        try
        {
            return await _routeRepository.FindAllAsync();
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public async Task<TravelRoute> FindByIdAsync(int id)
    {
        try
        {
            var travelRoute = await _routeRepository.FindByIdAsync(id);
            if (travelRoute == null) throw new Exception("Registro Não encontrado");

            return travelRoute;
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    public async Task InsertAsync(RequestInsertTravelRouteDto dto)
    {
        try
        {
            var route = new TravelRoute(dto);
            await _routeRepository.InsertAsync(route);
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public async Task UpdateAsync(int id, TravelRoute route)
    {
        try
        {
            if (id != route.Id) throw new Exception("O id informado na rota é diferente do objeto");

            var routeFromDb = await _routeRepository.FindByIdAsync(id);

            if (routeFromDb == null) throw new Exception("Rota não encontrada");

            await _routeRepository.UpdateAsync(route);
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
}
