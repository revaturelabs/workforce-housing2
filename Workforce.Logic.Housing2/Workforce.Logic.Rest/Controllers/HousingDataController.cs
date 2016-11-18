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
  public class HousingDataController : ApiController
  {
    private readonly LogicHelper logicHelper = new LogicHelper();
    private readonly log4net.ILog log = LogHelper.GetLogger();

    /// <summary>
    /// CRUD: Read calls logicHelper to get all housingComplexes from service
    /// </summary>
    /// <returns>Task<HttpResponseMessage></returns>
    public async Task<HttpResponseMessage> Get()
    {
      try
      {
        var theResponse = Request.CreateResponse(HttpStatusCode.OK, await logicHelper.HousingDataGetAll());
        log.Info("HousingData Get Successful");
        return theResponse;
      }
      catch (Exception ex)
      {
        LogHelper.SendError(log, ex);
        return Request.CreateResponse(HttpStatusCode.BadRequest);
      }

    }

    /// <summary>
    /// post method to insert new housingData
    /// </summary>
    /// <param name="newData"></param>
    /// <returns></returns>
    public async Task<HttpResponseMessage> Post([FromBody]HousingDataDto newData)
    {
      try
      {
        if (await logicHelper.AddHousingData(newData))
        {
          var theResponse = Request.CreateResponse(HttpStatusCode.OK, "successful insert");
          log.Info("HousingData Post Successful");
          return theResponse;
        }
        log.Info("HousingData Post Unsuccessful");
        return Request.CreateResponse(HttpStatusCode.BadRequest, "failed to insert");
      }
      catch (Exception ex)
      {
        LogHelper.SendError(log, ex);
        return Request.CreateResponse(HttpStatusCode.BadRequest, "failed to insert");
      }
    }

    public async Task<HttpResponseMessage> Delete(int id)
    {
      try
      {
        var thisData = await logicHelper.HousingDataGetAll();
        var thisHousingData = thisData.Find(x => x.AssociateID == id);
        if (await logicHelper.DeleteHousingData(thisHousingData))
        {
          log.Info("HousingData Delete Successful");
          return Request.CreateResponse(HttpStatusCode.OK, "successful deletion");
        }
        log.Info("HousingData Delete Unsuccessful");
        return Request.CreateResponse(HttpStatusCode.BadRequest, "failed to delete");
      }
      catch (Exception ex)
      {
        LogHelper.SendError(log, ex);
        return Request.CreateResponse(HttpStatusCode.BadRequest, "failed to delete");
      }
    }
  }
}

