using System.IO;

namespace Domain.Dtos;

public class ResponseGetTravelDto
{
    public int Cost { get; set; }
    public List<string> Route = new List<string>();
    public string FullRoute{ 
        private set{} 
        get
        {
            if (Route.Count() < 1) return "";
            return string.Join(" - ", Route);
        }
    }
}
