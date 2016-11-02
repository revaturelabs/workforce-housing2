﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Workforce.Logic.Housing2.Domain.Helpers;
using Workforce.Logic.Housing2.TransferModels;

namespace Workforce.Logic.Housing2.Rest.Controllers
{

   [EnableCors(origins: "*", headers: "*", methods: "*")]
   public class AssociateController : ApiController
   {

      //AssociatesGetByApartment()AssociatesGetRoomless

      AssociateHelper associateHelper = new AssociateHelper();

      /// <summary>
      /// http get method if -1 is passed in we get associates who are roomless otherwise we return all associate
      /// that are in the given apartment
      /// </summary>
      /// <param name="associate"></param>
      /// <returns></returns>
      public async Task<HttpResponseMessage> Get([FromUri] InsertAssociateDto associate)
      {
         if (associate.AssociateId.Equals(-1))
         {
            return Request.CreateResponse(HttpStatusCode.OK, await associateHelper.AssociatesGetRoomless());
         }
         return Request.CreateResponse(HttpStatusCode.OK, await associateHelper.AssociatesGetByApartment(associate));
      }

      /// <summary>
      /// http post to post associate into room
      /// </summary>
      /// <param name="associate"></param>
      /// <returns></returns>
      public async Task<HttpResponseMessage> Post([FromBody]InsertAssociateDto associate)
      {
         if (await associateHelper.InsertAssociateToRoom(associate))
         {
            return Request.CreateResponse(HttpStatusCode.OK, "Successfully registered associate into a apartment room");
         }
         return Request.CreateResponse(HttpStatusCode.OK, "failed to insert associate into a apartment room");
      }

      /// <summary>
      /// not implemented yet but we want this to change associate to a different room
      /// </summary>
      /// <param name="associate"></param>
      /// <returns></returns>
      public async Task<HttpResponseMessage> Put([FromBody]InsertAssociateDto associate)
      {
         if (await associateHelper.ChangeAssocToDifferentRoom(associate))
         {
            return Request.CreateResponse(HttpStatusCode.OK, "successfully moved associate to another apartment room");
         }
         return Request.CreateResponse(HttpStatusCode.OK, "failed to move associate to another apartment room");
      }

      /// <summary>
      /// this method deletes assocaite from a room
      /// </summary>
      /// <param name="associate"></param>
      /// <returns></returns>
      public async Task<HttpResponseMessage> Delete([FromBody]InsertAssociateDto associate)
      {
         if (await associateHelper.RemoveAssocFromRoom(associate))
         {
            return Request.CreateResponse(HttpStatusCode.OK, "successfully removed associate from apartment room");
         }
         return Request.CreateResponse(HttpStatusCode.OK, "failed to remove assocaiate from apartment room");
      }
   }
}