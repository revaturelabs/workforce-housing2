using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Workforce.Data.Housing.Soap.Validators
{
  public class CoreValidator
  {
    public bool StringValidate(string testString, int maxLength)
    {
      if(testString == string.Empty)
      {
        return false;
      }
        else
      {
        if (testString.Length > maxLength)
          return false;
      }

      return true;
    }


    public bool IntValidate(int testInt)
    {
      if (testInt < 0)
      {
        return false;
      }

      return true;
    }

    public bool PrimaryKeyValidate(int testInt)
    {
      if (testInt < 0)
      {
        return false;
      }

      return true;
    }

    public bool ForeignKeyValidate(Nullable<int> testInt)
    {
      if (testInt == null)
      {
        return false;
      }
      
      if(testInt < 0)
      {
        return false;
      }

      return true;
    }
  }
}