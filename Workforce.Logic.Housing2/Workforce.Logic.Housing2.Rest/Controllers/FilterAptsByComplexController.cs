using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Workforce.Logic.Housing2.Helpers;
using Workforce.Logic.Housing2.TransferModels;

namespace Workforce.Logic.Housing2.Rest.Controllers
{
   [EnableCors(origins: "*", headers: "*", methods: "*")]
   public class FilterAptsByComplexController : ApiController
   {
      private readonly LogicHelper logicHelper = new LogicHelper();

      public async Task<HttpResponseMessage> Get([FromUri]HousingComplexDto complex)
      {
         //var TargetHotApt = JsonConvert.DeserializeObject<HotelApartmentDTO>(o.ToString());
         return Request.CreateResponse(HttpStatusCode.OK, await logicHelper.FilterAptByComplex(complex));
      }
   }
}