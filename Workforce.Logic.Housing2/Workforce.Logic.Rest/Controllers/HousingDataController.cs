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

    /// <summary>
    /// CRUD: Read calls logicHelper to get all housingComplexes from service
    /// </summary>
    /// <returns>Task<HttpResponseMessage></returns>
    public async Task<HttpResponseMessage> Get()
    {
      Logger log = new Logger();
      log.InfoLog();
      try
      {
        return Request.CreateResponse(HttpStatusCode.OK, await logicHelper.HousingDataGetAll());
      }
      catch(Exception ex)
      {
        var error = "The error is this: " +  ex.InnerException.ToString();
        log.ErrorLog(error);
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
      if(await logicHelper.AddHousingData(newData))
      {
        return Request.CreateResponse(HttpStatusCode.OK, "successful insert");
      }
      return Request.CreateResponse(HttpStatusCode.BadRequest, "failed to insert");
    }

    public async Task<HttpResponseMessage> Delete(int id)
    {
      var thisData = await logicHelper.HousingDataGetAll();
      var thisHousingData = thisData.Find(x => x.AssociateID == id);
      if (await logicHelper.DeleteHousingData(thisHousingData))
      {
        return Request.CreateResponse(HttpStatusCode.OK, "successful deletion");
      }
      return Request.CreateResponse(HttpStatusCode.BadRequest, "failed to delete");
    }
  }
}
