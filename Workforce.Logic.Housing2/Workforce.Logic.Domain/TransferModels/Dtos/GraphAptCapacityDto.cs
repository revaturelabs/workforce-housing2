using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workforce.Logic.Domain.TransferModels.Dtos
{
  public class GraphAptCapacityDto
  {
    public string name { get; set; }
    public int maxCapacity { get; set; }
    public int currentCapacity { get; set; }
    //public int HotelId { get; set; }
  }
}
