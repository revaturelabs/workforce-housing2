using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.IO;

namespace Workforce.Logic.Rest.Controllers
{
  public class LogController : ApiController
  {

    public async Task<HttpResponseMessage> Get()
    {
      var path = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "../HousingLogicLog.log"; //the name of the latest log
      var reader = new StreamReader(path);
      string LogInformation = await reader.ReadToEndAsync();
      reader.Dispose();
      return Request.CreateResponse(HttpStatusCode.OK, LogInformation);
    }

  }
}

