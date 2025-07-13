namespace Domain.Dtos;

public class RequestInsertTravelRouteDto
{
    public string Origin { get; set; }
    public string Destination { get; set; }
    public int Price { get; set; }
}
