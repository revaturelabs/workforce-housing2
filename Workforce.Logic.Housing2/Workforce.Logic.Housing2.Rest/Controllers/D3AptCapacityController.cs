using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Workforce.Logic.Housing2.Helpers;

namespace Workforce.Logic.Housing2.Rest.Controllers
{
   [EnableCors(origins: "*", headers: "*", methods: "*")]
   public class D3AptCapacityController : ApiController
   {

      D3jsHelper d3jsHelper = new D3jsHelper();

      /// <summary>
      /// get method to generate the data needed for the d3js graph to consume this data
      /// </summary>
      /// <returns></returns>
      public async Task<HttpResponseMessage> Get()
      {
         return Request.CreateResponse(HttpStatusCode.OK, await d3jsHelper.ReturnGraphAptCapacity());
      }
   }
}