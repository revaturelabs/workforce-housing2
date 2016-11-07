using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workforce.Logic.Domain.TransferModels.Dtos
{
  public class AssociateDto
  {
    public int AssociateID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }  
    public int BatchID { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public bool HasCar { get; set; }
    public bool HasKeys { get; set; }
    public bool? IsComing { get; set; }
  }
}
