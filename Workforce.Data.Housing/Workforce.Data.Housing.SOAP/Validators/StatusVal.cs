﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workforce.Data.Housing.Soap.ServiceModels;
using Workforce.Data.Housing.Domain;

namespace Workforce.Data.Housing.Soap.Validators
{
  public class StatusVal
  {
    private readonly CoreValidator val = new CoreValidator();

    public bool Validate(Status stat)
    {

      if (val.PrimaryKeyValidate(stat.StatusID)
        && val.StringValidate(stat.StatusColor, 15)
        && val.StringValidate(stat.StatusMessage, 200))
      {
        return true;
      }


      return false;
    }

    public bool Validate(StatusDao stat)
    {
      if (val.PrimaryKeyValidate(stat.StatusID)
        && val.StringValidate(stat.StatusColor, 15)
        && val.StringValidate(stat.StatusMessage, 200))
      {
        return true;
      }


      return false;
    }
  }
}