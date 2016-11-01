using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workforce.Data.Housing.Domain;
using Workforce.Data.Housing.SOAP.ServiceModels;

namespace Workforce.Data.Housing.SOAP.Validators
{
  public class HousingComplexVal
  {
    private readonly CoreValidator val = new CoreValidator();

    public bool Validate(HousingComplex housing)
    {

      if (val.StringValidate(housing.Address, 500)
        && val.PrimaryKeyValidate(housing.HotelID)
        && val.StringValidate(housing.Name, 200)
        && val.StringValidate(housing.PhoneNumber, 20))
      {
        return true;
      }


      return false;
    }

    public bool Validate(HousingComplexDao housing)
    {
      if (val.StringValidate(housing.Address, 500)
        && val.PrimaryKeyValidate(housing.HotelID)
        && val.StringValidate(housing.Name, 200)
        && val.StringValidate(housing.PhoneNumber, 20))
      {
        return true;
      }


      return false;
    }
  }
}