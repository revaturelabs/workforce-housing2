using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workforce.Data.Housing.Domain;
using Workforce.Data.Housing.SOAP.ServiceModels;

namespace Workforce.Data.Housing.SOAP.Validators
{
  public class HousingDataVal
  {
    private readonly CoreValidator val = new CoreValidator();

    public bool Validate(HousingData housing)
    {

      if (val.PrimaryKeyValidate(housing.AssociateID)
        && val.ForeignKeyValidate(housing.StatusID)
        && val.ForeignKeyValidate(housing.RoomID))
      {
        return true;
      }


      return false;
    }

    public bool Validate(HousingDataDao housing)
    {
      if (val.PrimaryKeyValidate(housing.AssociateID)
        && val.ForeignKeyValidate(housing.StatusID)
        && val.ForeignKeyValidate(housing.RoomID))
      {
        return true;
      }


      return false;
    }
  }
}