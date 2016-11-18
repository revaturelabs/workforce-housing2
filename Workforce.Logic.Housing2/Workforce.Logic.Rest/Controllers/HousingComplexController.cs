using System;
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
  public class HousingComplexController : ApiController
  {
    private readonly LogicHelper logicHelper = new LogicHelper();
    private readonly log4net.ILog log = LogHelper.GetLogger();
    /// <summary>
    /// CRUD: Read calls logicHelper to get all housingComplexes from service
    /// </summary>
    /// <returns>Task<HttpResponseMessage></returns>
    public async Task<HttpResponseMessage> Get()//[FromUri] bool getActive)
    {
      try
      {
        bool getActive = true;
        if (getActive)
        {
          var Response1 = Request.CreateResponse(HttpStatusCode.OK, await logicHelper.HousingComplexsGetActive());
          log.Info("HousingComplex Get Successful");
          return Response1;
        }
        var Response2 = Request.CreateResponse(HttpStatusCode.OK, await logicHelper.HousingComplexsGetAll());
        log.Info("HousingComplex Get Successful");
        return Response2;
      }
      catch (Exception ex)
      {
        LogHelper.SendError(log, ex);
        return Request.CreateResponse(HttpStatusCode.BadRequest);
      }
    }

    /// <summary>
    /// post method to insert a new complex
    /// </summary>
    /// <param name="newHousingComDto"></param>
    /// <returns></returns>
    public async Task<HttpResponseMessage> Post([FromBody]HousingComplexDto newHousingComDto)
    {
      try
      {
        newHousingComDto.ActiveBit = true;
        if (await logicHelper.AddHousingComplex(newHousingComDto))
        {
          var Response1 = Request.CreateResponse(HttpStatusCode.OK, "successfully inserted");
          log.Info("HousingComplex Post Successful");
          return Response1;
        }
        var Response2 = Request.CreateResponse(HttpStatusCode.BadRequest, "failed to insert");
        log.Info("HousingComplex Post Unsuccessful");
        return Response2;
      }
      catch (Exception ex)
      {
        LogHelper.SendError(log, ex);
        return Request.CreateResponse(HttpStatusCode.BadRequest);
      }
    }

    /// <summary>
    /// put method for HousingComplex
    /// </summary>
    /// <param name="complex"></param>
    /// <returns></returns>
    public async Task<HttpResponseMessage> Put([FromBody]HousingComplexDto complex)
    {
      try
      {
        if (await logicHelper.UpdateHousingComplex(complex))
        {
          var Response1 = Request.CreateResponse(HttpStatusCode.OK, "successfully updated");
          log.Info("HousingComplex Put Successful");
          return Response1;
        }
        var Response2 = Request.CreateResponse(HttpStatusCode.BadRequest, "failed to update");
        log.Info("HousingComplex Put Unsuccessful");
        return Response2;
      }
      catch (Exception ex)
      {
        LogHelper.SendError(log, ex);
        return Request.CreateResponse(HttpStatusCode.BadRequest);
      }
    }
    /// <summary>
    /// Delete method for Housing Complex
    /// </summary>
    /// <param name="complex"></param>
    /// <returns></returns>
    public async Task<HttpResponseMessage> Delete([FromBody]HousingComplexDto complex)
    {
      try
      {
        if (await logicHelper.DeleteComplex(complex))
        {
          var Response1 = Request.CreateResponse(HttpStatusCode.OK, "successfully delete");
          log.Info("HousingComplex Delete Successful");
          return Response1;
        }
        var Response2 = Request.CreateResponse(HttpStatusCode.BadRequest, "failed to delete");
        log.Info("HousingComplex Delete Unsuccessful");
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