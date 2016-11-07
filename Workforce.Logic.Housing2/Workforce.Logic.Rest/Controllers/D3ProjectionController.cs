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

    D3jsHelper d3jsHelper = new D3jsHelper();

    public async Task<HttpResponseMessage> Get([FromUri] DateTime projectionDate)
    {
      return Request.CreateResponse(HttpStatusCode.OK, await d3jsHelper.ReturnGraphProjection(projectionDate));
    }

  }
}
