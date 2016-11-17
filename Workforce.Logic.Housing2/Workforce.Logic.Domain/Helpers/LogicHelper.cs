using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workforce.Logic.Domain.HousingReference;
using Workforce.Logic.Domain.Models;
using Workforce.Logic.Domain.TransferModels.Dtos;


namespace Workforce.Logic.Domain.Helpers
{
  public class LogicHelper
  {

    private readonly GraceServiceClient graceService = new GraceServiceClient();

    #region GetAlls()

    /// <summary>
    /// This method calls the soap service and awaits on the get
    /// </summary>
    /// <returns>  List<ApartmentDto> apartments  </returns>
    public async Task<List<ApartmentDto>> ApartmentsGetAll()
    {
      Apartment apartmentVnM = new Apartment();
      var daoApartments = await graceService.GetApartmentsAsync();
      var dtoApartments = apartmentVnM.getDtoList(daoApartments);
      //STILL NEED TO VALIDATE
      return dtoApartments;
    }
    /// <summary>
    /// this method gets all the active apartments
    /// </summary>
    /// <returns></returns>
    public async Task<List<ApartmentDto>> ApartmentsGetActvie()
    {
      Apartment apartmentVnM = new Apartment();
      //var daoApartments = await graceService.GetApartmentsAsync();
      var dtoApartments = apartmentVnM.getActiveDtoList(await graceService.GetApartmentsAsync());
      //STILL NEED TO VALIDATE
      return dtoApartments;
    }
    /// <summary>
    /// This method calls the soap service and awaits on the get
    /// </summary>
    /// <returns> List<HousingComplexDto> </returns>
    public async Task<List<HousingComplexDto>> HousingComplexsGetAll()
    {

      HousingComplex housingComplexVnM = new HousingComplex();
      var daoComplexes = await graceService.GetComplexesAsync();
      var dtoComplexes = await housingComplexVnM.getDtoList(daoComplexes);

      //STILL NEED TO VALIDATE
      return dtoComplexes;
    }
    /// <summary>
    /// method to get the active housingcomplexes
    /// </summary>
    /// <returns></returns>
    public async Task<List<HousingComplexDto>> HousingComplexsGetActive()
    {

      HousingComplex housingComplexVnM = new HousingComplex();
      var dtoComplexes = await housingComplexVnM.getActiveDtoList(await graceService.GetComplexesAsync());

      //STILL NEED TO VALIDATE
      return dtoComplexes;

    }


    /// <summary>
    ///  This method calls the soap service and awaits on the get
    /// </summary>
    /// <returns>  List<HousingDataDto> </returns>
    public async Task<List<HousingDataDto>> HousingDataGetAll()
    {

      HousingData housingDataVnM = new HousingData();
      var daoDatas = await graceService.GetHousingDataAsync();
      var dtoDatas = housingDataVnM.getDtoList(daoDatas);

      //STILL NEED TO VALIDATE
      return dtoDatas;
    }

    /// <summary>
    /// This method calls the soap service and awaits on the get
    /// </summary>
    /// <returns> List<StatusDto> </returns>
    public async Task<List<StatusDto>> StatusesGetAll()
    {

      Status statusVnM = new Status();
      var daoStatuses = await graceService.GetStatusesAsync();
      var dtoStatuses = statusVnM.getDtoList(daoStatuses);

      //STILL NEED TO VALIDATE
      return dtoStatuses;


    }

    #endregion

    #region updates for all models
    /// <summary>
    /// THIS METHOD UPDATES THE ApartmentDto
    /// </summary>
    /// <param name="fixApt"></param>
    /// <returns>Task<bool></returns>
    public async Task<bool> UpdateApartment(ApartmentDto fixApt)
    {
      Apartment apartmentVnM = new Apartment();

      //validate the incoming DTO first before converting into DAO
      //STILL NEED TO VALIDATE

      return await graceService.UpdateApartmentAsync(apartmentVnM.MapToDao(fixApt));
    }
    /// <summary>
    /// this method updates the HousingComplexDto
    /// </summary>
    /// <param name="fixComplex"></param>
    /// <returns>Task<bool></returns>
    public async Task<bool> UpdateHousingComplex(HousingComplexDto fixComplex)
    {
      HousingComplex housingComplexVnM = new HousingComplex();

      //validate the incoming DTO first before converting into DAO
      //STILL NEED TO VALIDATE

      return await graceService.UpdateHousingComplexAsync(housingComplexVnM.MapToDao(fixComplex));
    }
    /// <summary>
    /// this method updates the StatusDto
    /// </summary>
    /// <param name="fixStatus"></param>
    /// <returns>Task<bool></returns>
    public async Task<bool> UpdateStatus(StatusDto fixStatus)
    {
      Status statusVnM = new Status();

      return await graceService.UpdateStatusAsync(statusVnM.MapToDao(fixStatus));
    }
    /// <summary>
    /// This method updates the HousingDataDto
    /// </summary>
    /// <param name="fixData"></param>
    /// <returns>Task<bool></returns>
    public async Task<bool> UpdateHousingData(HousingDataDto fixData)
    {
      HousingData dataVnM = new HousingData();

      return await graceService.UpdateHousingDataAsync(dataVnM.MapToDao(fixData));
    }
    #endregion



    #region Insert methods for all models

    /// <summary>
    /// this method inserts a new apartment by calling on the soap service. 
    /// The "graceService.insert" returns a bool value so we just return 
    /// that since it depends on its pass or fail
    /// </summary>
    /// <param name="newApt"></param>
    /// <returns></returns>
    public async Task<bool> AddApartment(ApartmentDto newApt)
    {
      try
      {
        Apartment apartmentVnM = new Apartment();

        //validate the incoming DTO first before converting into DAO
        //STILL NEED TO VALIDATE

        return await graceService.InsertApartmentAsync(apartmentVnM.MapToDao(newApt));

      }
      catch (Exception)
      {
        return false;
      }
    }
    /// <summary>
    /// this method inserts a new complex by calling on the soap service. 
    /// The "graceService.insert" returns a bool value so we just return 
    /// that since it depends on its pass or fail
    /// </summary>
    /// <param name="newComplex"></param>
    /// <returns>Task<bool></returns>
    public async Task<bool> AddHousingComplex(HousingComplexDto newComplex)
    {
      try
      {
        HousingComplex housingComplexVnM = new HousingComplex();

        //validate the incoming DTO first before converting into DAO
        //STILL NEED TO VALIDATE

        return await graceService.InsertHousingComplexAsync(housingComplexVnM.MapToDao(newComplex));
      }
      catch (Exception)
      {
        return false;
      }
    }
    /// <summary>
    /// this method inserts a new housingData by calling on the soap service. 
    /// The "graceService.insert" returns a bool value so we just return 
    /// that since it depends on its pass or fail
    /// </summary>
    /// <param name="newData"></param>
    /// <returns>Task<bool></returns>
    public async Task<bool> AddHousingData(HousingDataDto newData)
    {
      try
      {
        HousingData housingDataVnM = new HousingData();

        //validate the incoming DTO first before converting into DAO
        //STILL NEED TO VALIDATE

        return await graceService.InsertHousingDataAsync(housingDataVnM.MapToDao(newData));
      }
      catch (Exception)
      {
        return false;
      }
    }
    /// <summary>
    /// this method inserts a new status by calling on the soap service. 
    /// The "graceService.insert" returns a bool value so we just return 
    /// that since it depends on its pass or fail
    /// </summary>
    /// <param name="newStatus"></param>
    /// <returns>Task<bool></returns>
    public async Task<bool> AddStatus(StatusDto newStatus)
    {
      try
      {
        Status statusVnM = new Status();

        //validate the incoming DTO first before converting into DAO
        //STILL NEED TO VALIDATE

        return await graceService.InsertStatusAsync(statusVnM.MapToDao(newStatus));
      }
      catch (Exception)
      {
        return false;
      }
    }


    #endregion

    #region delete methods for each and all models

    /// <summary>
    /// This method recieves an ApartmentDto model that we expect to delete based off of the primary key
    /// </summary>
    /// <param name="oldApartment"></param>
    /// <returns>Task<bool></returns>
    public async Task<bool> DeleteApartment(ApartmentDto oldApartment)
    { 

      Apartment ApartmentVnM = new Apartment();

      //validate the incoming DTO first before converting into DAO
      //STILL NEED TO VALIDATE

      return await graceService.DeleteApartmentAsync(ApartmentVnM.MapToDao(oldApartment));


    }
    /// <summary>
    /// This method recieves an HousingComlexDto model that we expect to delete based off of the primary key
    /// </summary>
    /// <param name="oldComplex"></param>
    /// <returns>Task<bool></returns>
    public async Task<bool> DeleteComplex(HousingComplexDto oldComplex)
    {

      HousingComplex housingComplexVnM = new HousingComplex();
        
      //validate the incoming DTO first before converting into DAO
      //STILL NEED TO VALIDATE
       
      //first we get the currentOccupancy, if its greater then ZERO then return false
      int currOccupancy = await housingComplexVnM.returnComplexCurCap(oldComplex);
      if (currOccupancy > 0)
      {
        return false;
      }

      else
      {
        return await graceService.DeleteHousingComplexAsync(housingComplexVnM.MapToDao(oldComplex));
      }

    }
    /// <summary>
    /// This method recieves an HousingDataDto model that we expect to delete based off of the primary key
    /// </summary>
    /// <param name="oldData"></param>
    /// <returns>Task<bool></returns>
    public async Task<bool> DeleteHousingData(HousingDataDto oldData)
    {

      HousingData housingDataVnM = new HousingData();

      //validate the incoming DTO first before converting into DAO
      //STILL NEED TO VALIDATE


      return await graceService.DeleteHousingDataAsync(housingDataVnM.MapToDao(oldData));

    }
    /// <summary>
    /// This method recieves an StatusDto model that we expect to delete based off of the primary key
    /// </summary>
    /// <param name="oldStatus"></param>
    /// <returns>Task<bool></returns>
    public async Task<bool> DeleteStatus(StatusDto oldStatus)
    {

      Status statusVnM = new Status();

      //validate the incoming DTO first before converting into DAO
      //STILL NEED TO VALIDATE

      return await graceService.DeleteStatusAsync(statusVnM.MapToDao(oldStatus));

    }

    #endregion

    #region Method to filter 

    /// <summary>
    /// This method returns a list of apartments within the given HousingComplex
    /// </summary>
    /// <param name="complex"></param>
    /// <returns>Task<List<ApartmentDto>></returns>
    public async Task<List<ApartmentDto>> FilterAptByComplex(HousingComplexDto complex)
    {
      List<ApartmentDto> returnList = new List<ApartmentDto>();
      foreach (var item in await ApartmentsGetActvie())
      {
        if (item.HotelID.Equals(complex.HotelID))
        {
          returnList.Add(item);
        }
      }
      return returnList;
    }

    #endregion

  }
}
