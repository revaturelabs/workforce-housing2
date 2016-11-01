using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workforce.Data.Housing.Domain
{
  /// <summary>
  /// This AccessHelper will provide the Get, Inserts, Updates and Deletes for all Project
  /// Grace tables
  /// </summary>
  public class AccessHelper
  {
    private readonly WorkforceHousingDB_Entities db;
    public AccessHelper()
    {
      db = new WorkforceHousingDB_Entities();
    }
    public AccessHelper(WorkforceHousingDB_Entities db)
    {
      this.db = db;
    }

    #region GetsGrace
    /// <summary>
    /// Returns a list of HousingComplex
    /// </summary>
    /// <returns></returns>
    public List<HousingComplex> GetComplexes()
    {
      return db.HousingComplex.ToList();
    }

    /// <summary>
    /// Return a list of Apartment
    /// </summary>
    /// <returns></returns>
    public List<Apartment> GetApartments()
    {
      return db.Apartment.ToList();
    }

    /// <summary>
    /// Return a list of HousingData
    /// </summary>
    /// <returns></returns>
    public List<HousingData> GetHousingData()
    {
      return db.HousingData.ToList();
    }

    /// <summary>
    /// Returns a list of Statuses
    /// </summary>
    /// <returns></returns>
    public List<Status> GetStatuses()
    {
      return db.Status.ToList();
    }
    #endregion
    #region InsertGrace

    /// <summary>
    /// Will insert an Apartment into the database
    /// </summary>
    /// <param name="apt"></param>
    /// <returns>return true if added</returns>
    public bool InsertApartment(Apartment apt)
    {
      apt.ActiveBit = true;
      try
      {
        db.Apartment.Add(apt);
        if (db.SaveChanges() == 0)
        {
          return false;
        }
        return true;
      }
      catch (Exception)
      {
        return false;
      }
    }

    /// <summary>
    /// Will insert a HousingComplex into the database
    /// </summary>
    /// <param name="housecom"></param>
    /// <returns>return true if added</returns>
    public bool InsertHousingComplex(HousingComplex housecom)
    {
      housecom.ActiveBit = true;
      try
      {
        db.HousingComplex.Add(housecom);
        if (db.SaveChanges() == 0)
        {
          return false;
        }
        return true;
      }
      catch (Exception)
      {
        return false;
      }
    }

    /// <summary>
    /// Will insert a HousingData into the database
    /// </summary>
    /// <param name="housedat"></param>
    /// <returns>return true if added</returns>
    public bool InsertHousingData(HousingData housedat)
    {
      try
      {
        db.HousingData.Add(housedat);
        if (db.SaveChanges() == 0)
        {
          return false;
        }
        return true;
      }
      catch (Exception)
      {
        return false;
      }
    }

    /// <summary>
    /// Will insert a Status into the database
    /// </summary>
    /// <param name="stat"></param>
    /// <returns>true if inserted</returns>
    public bool InsertStatus(Status stat)
    {
      stat.ActiveBit = true;
      try
      {
        db.Status.Add(stat);
        if (db.SaveChanges() == 0)
        {
          return false;
        }
        return true;
      }
      catch (Exception)
      {
        return false;
      }
    }

    #endregion
    #region UpdateGrace

    /// <summary>
    /// Will update the Apartment in the database
    /// </summary>
    /// <param name="apt"></param>
    /// <returns>return true if object found</returns>
    public bool UpdateApartment(Apartment apt)
    {
      try
      {
        var oldapt = db.Apartment.FirstOrDefault(a => a.RoomID == apt.RoomID);
        if (oldapt != null)
        {
          db.Entry(oldapt).CurrentValues.SetValues(apt);
          db.SaveChanges();
          return true;
        }
        return false;
      }
      catch (Exception)
      {
        return false;
      }
    }

    /// <summary>
    /// Will update HousingComplex in database
    /// </summary>
    /// <param name="housecom"></param>
    /// <returns>return true if object found</returns>
    public bool UpdateHousingComplex(HousingComplex housecom)
    {
      try
      {
        var oldhousecom = db.HousingComplex.FirstOrDefault(h => h.HotelID == housecom.HotelID);
        if (oldhousecom != null)
        {
          db.Entry(oldhousecom).CurrentValues.SetValues(housecom);
          db.SaveChanges();
          return true;
        }
        return false;
      }
      catch (Exception)
      {
        return false;
      }
    }

    /// <summary>
    /// Will update HousingData in database
    /// </summary>
    /// <param name="housedata"></param>
    /// <returns>return true if object found</returns>
    public bool UpdateHousingData(HousingData housedata)
    {
      try
      {
        var oldhousedata = db.HousingData.FirstOrDefault(h => h.AssociateID == housedata.AssociateID);
        if (oldhousedata != null)
        {
          db.Entry(oldhousedata).CurrentValues.SetValues(housedata);
          db.SaveChanges();
          return true;
        }
        return false;
      }
      catch (Exception)
      {
        return false;
      }
    }

    /// <summary>
    /// Will update Status in the database
    /// </summary>
    /// <param name="stat"></param>
    /// <returns>return true if object found</returns>
    public bool UpdateStatus(Status stat)
    {
      try
      {
        var oldstat = db.HousingData.FirstOrDefault(s => s.StatusID == stat.StatusID);
        if (oldstat != null)
        {
          db.Entry(oldstat).CurrentValues.SetValues(stat);
          db.SaveChanges();
          return true;
        }
        return false;
      }
      catch (Exception)
      {
        return false;
      }
    }

    #endregion
    #region DeleteGrace
    /// <summary>
    /// Will delet the Apartment by setting Active bit
    /// </summary>
    /// <param name="apt"></param>
    /// <returns>return true if object found</returns>
    public bool DeleteApartment(Apartment apt)
    {
      try
      {
        var oldapt = db.Apartment.FirstOrDefault(a => a.RoomID == apt.RoomID);
        if (oldapt != null)
        {
          apt = oldapt;
          apt.ActiveBit = false;
          db.Entry(oldapt).CurrentValues.SetValues(apt);
          db.SaveChanges();
          return true;
        }
        return false;
      }
      catch (Exception)
      {
        return false;
      }
    }

    /// <summary>
    /// Will delete HousingComplex by setting Active bit
    /// </summary>
    /// <param name="housecom"></param>
    /// <returns>return true if object found</returns>
    public bool DeleteHousingComplex(HousingComplex housecom)
    {
      try
      {
        var oldhousecom = db.HousingComplex.FirstOrDefault(h => h.HotelID == housecom.HotelID);
        if (oldhousecom != null)
        {
          housecom = oldhousecom;
          housecom.ActiveBit = false;
          db.Entry(oldhousecom).CurrentValues.SetValues(housecom);
          db.SaveChanges();
          return true;
        }
        return false;
      }
      catch (Exception)
      {
        return false;
      }
    }

    /// <summary>
    /// Will delete HousingData by setting StatusID to Red (3)
    /// </summary>
    /// <param name="housedata"></param>
    /// <returns>return true if object found</returns>
    public bool DeleteHousingData(HousingData housedata)
    {
      try
      {
        var oldhousedata = db.HousingData.FirstOrDefault(h => h.AssociateID == housedata.AssociateID);
        if (oldhousedata != null)
        {
          housedata = oldhousedata;
          housedata.StatusID = 3;
          db.Entry(oldhousedata).CurrentValues.SetValues(housedata);
          db.SaveChanges();
          return true;
        }
        return false;
      }
      catch (Exception)
      {
        return false;
      }
    }

    /// <summary>
    /// Will delete Status by setting Active bit
    /// </summary>
    /// <param name="stat"></param>
    /// <returns>return true if object found</returns>
    public bool DeleteStatus(Status stat)
    {
      try
      {
        var oldstat = db.Status.FirstOrDefault(s => s.StatusID == stat.StatusID);
        if (oldstat != null)
        {
          stat = oldstat;
          stat.ActiveBit = false;
          db.Entry(oldstat).CurrentValues.SetValues(stat);
          db.SaveChanges();
          return true;
        }
        return false;
      }
      catch (Exception)
      {
        return false;
      }
    }
    #endregion
  }
}
