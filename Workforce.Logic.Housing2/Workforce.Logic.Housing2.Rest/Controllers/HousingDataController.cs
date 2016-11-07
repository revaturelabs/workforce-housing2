﻿using System;
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
   //[EnableCors(origins: "*", headers: "*", methods: "*")]
   public class HousingDataController : ApiController
   {
      private readonly LogicHelper logicHelper = new LogicHelper();

      /// <summary>
      /// CRUD: Read calls logicHelper to get all housingComplexes from service
      /// </summary>
      /// <returns>Task<HttpResponseMessage></returns>
      public async Task<HttpResponseMessage> Get()
      {
         return Request.CreateResponse(HttpStatusCode.OK, await logicHelper.HousingDataGetAll());
      }

      /// <summary>
      /// post method to insert new housingData
      /// </summary>
      /// <param name="newData"></param>
      /// <returns></returns>
      public async Task<HttpResponseMessage> Post([FromBody]HousingDataDto newData)
      {
         if (await logicHelper.AddHousingData(newData))
         {
            return Request.CreateResponse(HttpStatusCode.OK, "successful insert");
         }
         return Request.CreateResponse(HttpStatusCode.OK, "failed to insert");
      }
   }
}