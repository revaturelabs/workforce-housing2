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
  public class StatusController : ApiController
  {
    private readonly log4net.ILog log = LogHelper.GetLogger();
    private readonly LogicHelper logicHelper = new LogicHelper();
    /// <summary>
    /// CRUD: Read calls logicHelper to get all Apartments from service
    /// </summary>
    /// <returns>Task<HttpResponseMessage></returns>
    public async Task<HttpResponseMessage> Get()
    {
      try
      {
        var Response = Request.CreateResponse(HttpStatusCode.OK, await logicHelper.StatusesGetAll());
        log.Info("Status Get Successful");
        return Response;
      }
      catch (Exception ex)
      {
        LogHelper.SendError(log, ex);
        return Request.CreateResponse(HttpStatusCode.BadRequest);
      }
    }

    /// <summary>
    /// post method for inserting new status
    /// </summary>
    /// <param name="newStatus"></param>
    /// <returns></returns>
    public async Task<HttpResponseMessage> Post([FromBody]StatusDto newStatus)
    {
      try
      {
        if (await logicHelper.AddStatus(newStatus))
        {
          var Response1 = Request.CreateResponse(HttpStatusCode.OK, "successful insert");
          log.Info("Status Post Successful");
          return Response1;
        }
        var Response2 = Request.CreateResponse(HttpStatusCode.BadRequest, "failed to insert");
        log.Info("Status Post Unsuccessful");
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
