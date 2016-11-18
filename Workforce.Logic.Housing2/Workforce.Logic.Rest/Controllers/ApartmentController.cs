using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Workforce.Logic.Domain.Helpers;
using Workforce.Logic.Domain.TransferModels.Dtos;

namespace Workforce.Logic.Rest.Controllers
{
  [EnableCors(origins: "*", headers: "*", methods: "*")]
  public class ApartmentController : ApiController
  {
    private readonly LogicHelper logicHelper = new LogicHelper();

    private readonly log4net.ILog log = LogHelper.GetLogger();
    /// <summary>
    /// CRUD: Read calls logicHelper to get all Apartments from service
    /// </summary>
    /// <returns>Task<HttpResponseMessage></returns>
    public async Task<HttpResponseMessage> Get()//[FromUri] bool getActive)
    {
      try
      {
        bool getActive = true;
        if (getActive)
        {
          var Response1 = Request.CreateResponse(HttpStatusCode.OK, await logicHelper.ApartmentsGetActvie());
          log.Info("Apartment Get Successful");
          return Response1;
        }
        var Response2 = Request.CreateResponse(HttpStatusCode.OK, await logicHelper.ApartmentsGetAll());
        log.Info("Apartment Get Successful");
        return Response2;
      }
      catch(Exception ex)
      {
        LogHelper.SendError(log, ex);
        return Request.CreateResponse(HttpStatusCode.BadRequest);
      }
    }

    /// <summary>
    /// post method for inserting a new apartment
    /// </summary>
    /// <param name="newApartmentDto"></param>
    /// <returns></returns>
    public async Task<HttpResponseMessage> Post([FromBody]ApartmentDto newApartmentDto)
    {
      try
      {
        newApartmentDto.ActiveBit = true;
        newApartmentDto.CurrentCapacity = 0;
        if (await logicHelper.AddApartment(newApartmentDto))
        {
          var Response1 = Request.CreateResponse(HttpStatusCode.OK, "successful insert");
          log.Info("Apartment Post Successful");
          return Response1;
        }
        var Response2 = Request.CreateResponse(HttpStatusCode.BadRequest, "failed to insert");
        log.Info("Apartment Post Unsuccessful");
        return Response2;
      }
      catch (Exception ex)
      {
        LogHelper.SendError(log, ex);
        return Request.CreateResponse(HttpStatusCode.BadRequest);
      }
    }
    /// <summary>
    /// put method for apartment
    /// </summary>
    /// <param name="apartment"></param>
    /// <returns></returns>
    public async Task<HttpResponseMessage> Put([FromBody]ApartmentDto apartment)
    {
      try
      {
        if (await logicHelper.UpdateApartment(apartment))
        { 
          var Response1 = Request.CreateResponse(HttpStatusCode.OK, "successful update");
          log.Info("Apartment Put Successful");
          return Response1;
        }
        var Response2 = Request.CreateResponse(HttpStatusCode.BadRequest, "failed to update");
        log.Info("Apartment Put Unsuccessful");
        return Response2;
      }
      catch (Exception ex)
      {
        LogHelper.SendError(log, ex);
        return Request.CreateResponse(HttpStatusCode.BadRequest);
      }
    }
    /// <summary>
    /// delete method for apartment
    /// </summary>
    /// <param name="apartment"></param>
    /// <returns></returns>
    public async Task<HttpResponseMessage> Delete([FromBody]ApartmentDto apartment)
    {
      try
      {
        if (await logicHelper.DeleteApartment(apartment))
        {
          var Response1 = Request.CreateResponse(HttpStatusCode.OK, "successful delete");
          log.Info("Apartment Delete Successful");
          return Response1;
        }
        var Response2 = Request.CreateResponse(HttpStatusCode.BadRequest, "failed to delete");
        log.Info("Apartment Delete Unsuccessful");
        return Response2;
      }
      catch (Exception ex)
      {
        LogHelper.SendError(log, ex);
        return Request.CreateResponse(HttpStatusCode.BadRequest);
      }
    }

  }
}
