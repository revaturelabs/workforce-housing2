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
  public class AssociateController : ApiController
  {

    //AssociatesGetByApartment()AssociatesGetRoomless

    AssociateHelper associateHelper = new AssociateHelper();
    private readonly log4net.ILog log = LogHelper.GetLogger();
    /// <summary>
    /// http get method if -1 is passed in we get associates who are roomless otherwise we return all associate
    /// that are in the given apartment
    /// </summary>
    /// <param name="associate"></param>
    /// <returns></returns>
    public async Task<HttpResponseMessage> Get([FromUri] InsertAssociateDto associate)
    {
      try
      {
        if (associate.AssociateId.Equals(-1))
        {
          var theResponseRmlss = Request.CreateResponse(HttpStatusCode.OK, await associateHelper.AssociatesGetRoomless());
          log.Info("Associate Get Successful");
          return theResponseRmlss;
        }
        var theResponseByAp = Request.CreateResponse(HttpStatusCode.OK, await associateHelper.AssociatesGetByApartment(associate));
        log.Info("Associate Get Successful");
        return theResponseByAp;
      }
      catch (Exception ex)
      {
        LogHelper.SendError(log, ex);
        return Request.CreateResponse(HttpStatusCode.BadRequest);
      }
    }

    /// <summary>
    /// http post to post associate into room
    /// </summary>
    /// <param name="associate"></param>
    /// <returns></returns>
    public async Task<HttpResponseMessage> Post([FromBody]InsertAssociateDto associate)
    {
      try
      {
        if (await associateHelper.InsertAssociateToRoom(associate))
        {
          var theResponseByAp = Request.CreateResponse(HttpStatusCode.OK, "Successfully registered associate into a apartment room");
          log.Info("Associate Post Successful");
          return theResponseByAp;
        }
        var theResponse2 = Request.CreateResponse(HttpStatusCode.BadRequest, "failed to insert associate into a apartment room");
        log.Info("Associate Post Unsuccessful");
        return theResponse2;
      }
      catch (Exception ex)
      {
        LogHelper.SendError(log, ex);
        return Request.CreateResponse(HttpStatusCode.BadRequest, "failed to insert associate into a apartment room");
      }
    }

    /// <summary>
    /// not implemented yet but we want this to change associate to a different room
    /// NOTE: This method may need to be removed as it's overall functionality does not seem needed in the long run
    /// </summary>
    /// <param name="associate"></param>
    /// <returns></returns>
    public HttpResponseMessage Put([FromBody]InsertAssociateDto associate)
    {
      //if (await associateHelper.ChangeAssocToDifferentRoom(associate))
      //{
      //  return Request.CreateResponse(HttpStatusCode.OK, "successfully moved associate to another apartment room");
      //}
      log.Info("Associate Put Unsuccessful");
      return Request.CreateResponse(HttpStatusCode.BadRequest, "failed to move associate to another apartment room");
    }

    /// <summary>
    /// this method deletes assocaite from a room
    /// </summary>
    /// <param name="associate"></param>
    /// <returns></returns>
    public async Task<HttpResponseMessage> Delete([FromBody]InsertAssociateDto associate)
    {
      try
      {
        if (await associateHelper.RemoveAssocFromRoom(associate))
        {
          var Response1 = Request.CreateResponse(HttpStatusCode.OK, "successfully removed associate from apartment room");
          log.Info("Associate Delete Successful");
          return Response1;
        }
        var Response2 = Request.CreateResponse(HttpStatusCode.BadRequest, "failed to remove assocaiate from apartment room");
        log.Info("Associate Delete Unsuccessful");
        return Response2;
      }
      catch(Exception ex)
      {
        LogHelper.SendError(log, ex);
        return Request.CreateResponse(HttpStatusCode.BadRequest, "failed to remove assocaiate from apartment room");
      }
    }
  }
}
