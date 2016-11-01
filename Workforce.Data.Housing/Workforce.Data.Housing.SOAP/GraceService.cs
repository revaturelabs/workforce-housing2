using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Workforce.Data.Housing.SOAP
{
  // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
  public class GraceService : IGraceService
  {
    private readonly AccessHelper ac = new AccessHelper();
    private readonly EfMapper emap = new EfMapper();
    private readonly ApartmentVal aptVal = new ApartmentVal();
    private readonly HousingComplexVal housingCVal = new HousingComplexVal();
    private readonly HousingDataVal housingDVal = new HousingDataVal();
    private readonly StatusVal statVal = new StatusVal();

    #region GETS
    /// <summary>
    /// This method grabs list of hosuing complexes from access helper and maps into daos to create new list
    /// </summary>
    /// <returns></returns>

    public List<HousingComplexDao> GetComplexes()
    {
      var housing = new List<HousingComplexDao>();
      var datahousing = ac.GetComplexes();

      foreach (var item in datahousing)
      {
        housing.Add(emap.MapToService(item));
      }

      return housing;
    }


    /// <summary>
    /// This method grabs list of apartments from access helper and maps into daos to create new list
    /// </summary>
    /// <returns></returns>
    public List<ApartmentDao> GetApartments()
    {
      var apartment = new List<ApartmentDao>();
      var dataapartment = ac.GetApartments();

      foreach (var item in dataapartment)
      {
        apartment.Add(emap.MapToService(item));
      }

      return apartment;
    }


    /// <summary>
    /// This method grabs list of housing data from access helper and maps into daos to create new list
    /// </summary>
    /// <returns></returns>
    public List<HousingDataDao> GetHousingData()
    {
      var hdata = new List<HousingDataDao>();
      var datahdata = ac.GetHousingData();

      foreach (var item in datahdata)
      {
        hdata.Add(emap.MapToService(item));
      }

      return hdata;
    }


    /// <summary>
    /// This method grabs list of status from access helper and maps into daos to create new list
    /// </summary>
    /// <returns></returns>
    public List<StatusDao> GetStatuses()
    {
      var status = new List<StatusDao>();
      var datastatus = ac.GetStatuses();

      foreach (var item in datastatus)
      {
        status.Add(emap.MapToService(item));
      }

      return status;
    }
    #endregion


    #region INSERTS
    public bool InsertApartment(ApartmentDao newapt)
    {
      try
      {
        if (aptVal.Validate(newapt))
        {
          ac.InsertApartment(emap.MapToData(newapt));
          return true;
        }
        else
        {
          return false;
        }
      }
      catch (Exception)
      {
        return false;
      }
    }

    public bool InsertHousingData(HousingDataDao newhdata)
    {
      try
      {
        if (housingDVal.Validate(newhdata))
        {
          ac.InsertHousingData(emap.MapToData(newhdata));
          return true;
        }
        else
        {
          return false;
        }
      }
      catch (Exception)
      {
        return false;
      }
    }


    public bool InsertHousingComplex(HousingComplexDao newhcomplex)
    {
      try
      {
        if (housingCVal.Validate(newhcomplex))
        {
          ac.InsertHousingComplex(emap.MapToData(newhcomplex));
          return true;
        }
        else
        {
          return false;
        }
      }
      catch (Exception)
      {
        return false;
      }
    }

    public bool InsertStatus(StatusDao newstatus)
    {
      try
      {
        if (statVal.Validate(newstatus))
        {
          ac.InsertStatus(emap.MapToData(newstatus));
          return true;
        }
        else
        {
          return false;
        }
      }
      catch (Exception)
      {
        return false;
      }
    }
    #endregion


    #region UPDATES

    public bool UpdateApartment(ApartmentDao apt)
    {
      try
      {
        if (aptVal.Validate(apt))
        {
          return (ac.UpdateApartment(emap.MapToData(apt)));
        }
        else
        {
          return false;
        }

      }
      catch (Exception)
      {
        return false;
      }
    }




    public bool UpdateHousingComplex(HousingComplexDao hcomplex)
    {
      try
      {
        if (housingCVal.Validate(hcomplex))
        {
          return (ac.UpdateHousingComplex(emap.MapToData(hcomplex)));
        }
        else
        {
          return false;
        }
      }
      catch (Exception)
      {
        return false;
      }
    }




    public bool UpdateHousingData(HousingDataDao hdata)
    {
      try
      {
        if (housingDVal.Validate(hdata))
        {
          return (ac.UpdateHousingData(emap.MapToData(hdata)));
        }
        else
        {
          return false;
        }

      }
      catch (Exception)
      {
        return false;
      }
    }




    public bool UpdateStatus(StatusDao status)
    {
      try
      {
        if (statVal.Validate(status))
        {
          return (ac.UpdateStatus(emap.MapToData(status)));
        }
        else
        {
          return false;
        }
      }
      catch (Exception)
      {
        return false;
      }
    }


    #endregion

    #region DELETES

    public bool DeleteApartment(ApartmentDao apt)
    {
      try
      {
        if (aptVal.Validate(apt))
        {
          ac.DeleteApartment(emap.MapToData(apt));
          return true;
        }
        else
        {
          return false;
        }
      }
      catch (Exception)
      {
        return false;
      }
    }

    public bool DeleteHousingData(HousingDataDao hdata)
    {
      try
      {
        if (housingDVal.Validate(hdata))
        {
          ac.DeleteHousingData(emap.MapToData(hdata));
          return true;
        }
        else
        {
          return false;
        }
      }
      catch (Exception)
      {
        return false;
      }
    }


    public bool DeleteHousingComplex(HousingComplexDao hcomplex)
    {
      try
      {
        if (housingCVal.Validate(hcomplex))
        {
          ac.DeleteHousingComplex(emap.MapToData(hcomplex));
          return true;
        }
        else
        {
          return false;
        }
      }
      catch (Exception)
      {
        return false;
      }
    }

    public bool DeleteStatus(StatusDao status)
    {
      try
      {
        if (statVal.Validate(status))
        {
          ac.DeleteStatus(emap.MapToData(status));
          return true;
        }
        else
        {
          return false;
        }
      }
      catch (Exception)
      {
        return false;
      }
    }


    #endregion
  }
}
