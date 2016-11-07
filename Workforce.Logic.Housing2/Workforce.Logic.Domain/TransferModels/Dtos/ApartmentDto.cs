using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workforce.Logic.Domain.TransferModels.Dtos
{
  public class ApartmentDto
  {

    public int RoomID { get; set; }
    public int RoomNumber { get; set; }
    public int CurrentCapacity { get; set; }
    public int MaxCapacity { get; set; }
    public int GenderID { get; set; }
    public int HotelID { get; set; }
    public bool ActiveBit { get; set; }

  }
}
