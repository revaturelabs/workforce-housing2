using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Workforce.Logic.Domain.Helpers;

namespace Workforce.Logic.Rest.Controllers
{

  [EnableCors(origins: "*", headers: "*", methods: "*")]
  public class D3ProjectionController : ApiController
  {

    private readonly log4net.ILog log = LogHelper.GetLogger();
    D3jsHelper d3jsHelper = new D3jsHelper();

    public async Task<HttpResponseMessage> Get([FromUri] DateTime projectionDate)
    {
      try
      {
        var Response = Request.CreateResponse(HttpStatusCode.OK, await d3jsHelper.ReturnGraphProjection(projectionDate));
        log.Info("D3Projection Get Successful");
        return Response;
      }
      catch(Exception ex)
      {
        LogHelper.SendError(log, ex);
        return Request.CreateResponse(HttpStatusCode.BadRequest);
      }
    }

  }
}
