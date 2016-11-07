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
  public class GetAssociatesController : ApiController
    {

    Consumers traineeConsumer = new Consumers();
    public async Task<HttpResponseMessage> Get([FromUri] ApartmentDto apartment)
    { 
      
      return Request.CreateResponse(HttpStatusCode.OK, await traineeConsumer.ConsumeAssociatesFromAPI());
    }
  }
}
