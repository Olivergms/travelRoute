using Domain.Dtos;
using System.ComponentModel.DataAnnotations;
namespace Domain.Entities;
public class TravelRoute
{
    [Key]
    public int Id { get; set; }
    public string Origin { get; set; }
    public string Destination { get; set; }
    public int Price { get; set; }

    public TravelRoute(){}
    public TravelRoute(RequestInsertTravelRouteDto dto)
    {
        Origin = dto.Origin.ToUpper();
        Destination = dto.Destination.ToUpper();
        Price = dto.Price;
    }
}
