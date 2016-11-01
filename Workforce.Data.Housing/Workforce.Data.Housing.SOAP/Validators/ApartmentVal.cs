using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workforce.Data.Housing.Domain;
using Workforce.Data.Housing.SOAP.ServiceModels;

namespace Workforce.Data.Housing.SOAP.Validators
{
  public class ApartmentVal
  {
    private readonly CoreValidator val = new CoreValidator();

    public bool Validate(Apartment apt)
    {

      if (val.IntValidate(apt.CurrentCapacity) 
        && val.IntValidate(apt.MaxCapacity) 
        && val.IntValidate(apt.RoomNumber)
        && val.ForeignKeyValidate(apt.HotelID)
        && val.ForeignKeyValidate(apt.GenderID)
        && val.PrimaryKeyValidate(apt.RoomID))
      {
        return true;
      }


      return false;
    }

    public bool Validate(ApartmentDao apt)
    {
      if (val.IntValidate(apt.CurrentCapacity)
        && val.IntValidate(apt.MaxCapacity)
        && val.IntValidate(apt.RoomNumber)
        && val.ForeignKeyValidate(apt.HotelID)
        && val.ForeignKeyValidate(apt.GenderID)
        && val.PrimaryKeyValidate(apt.RoomID))
      {
        return true;
      }


      return false;
    }
  }
}