using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos;

public class RequestTravelDto
{
    [Required]
    public string Origin { get; set; }
    [Required]
    public string Destination { get; set; }
}
