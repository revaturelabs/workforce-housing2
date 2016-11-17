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
  public class ApartmentController : ApiController
  {
    private readonly LogicHelper logicHelper = new LogicHelper();

    /// <summary>
    /// CRUD: Read calls logicHelper to get all Apartments from service
    /// </summary>
    /// <returns>Task<HttpResponseMessage></returns>
    public async Task<HttpResponseMessage> Get()//[FromUri] bool getActive)
    {
      bool getActive = true;
      if (getActive)
      {
        return Request.CreateResponse(HttpStatusCode.OK, await logicHelper.ApartmentsGetActvie());
      }
      return Request.CreateResponse(HttpStatusCode.OK, await logicHelper.ApartmentsGetAll());
    }

    /// <summary>
    /// post method for inserting a new apartment
    /// </summary>
    /// <param name="newApartmentDto"></param>
    /// <returns></returns>
    public async Task<HttpResponseMessage> Post([FromBody]ApartmentDto newApartmentDto)
    {
      newApartmentDto.ActiveBit = true;
      newApartmentDto.CurrentCapacity = 0;
      if (await logicHelper.AddApartment(newApartmentDto))
      {
        return Request.CreateResponse(HttpStatusCode.OK, "successfully inserted new Apartment/Room");
      }
      return Request.CreateResponse(HttpStatusCode.BadRequest, "failed to insert new Apartment/Room");
    }
    /// <summary>
    /// put method for apartment
    /// </summary>
    /// <param name="apartment"></param>
    /// <returns></returns>
    public async Task<HttpResponseMessage> Put([FromBody]ApartmentDto apartment)
    {
      if (await logicHelper.UpdateApartment(apartment))
      {
        return Request.CreateResponse(HttpStatusCode.OK, "successfully updated Apartment/Room Data");
      }
      return Request.CreateResponse(HttpStatusCode.BadRequest, "failed to update Apartment/Room Data");
    }
    /// <summary>
    /// delete method for apartment
    /// </summary>
    /// <param name="apartment"></param>
    /// <returns></returns>
    public async Task<HttpResponseMessage> Delete([FromBody]ApartmentDto apartment)
    {
      if (await logicHelper.DeleteApartment(apartment))
      {
        return Request.CreateResponse(HttpStatusCode.OK, "successfully deleted Apartment/Room Data");
      }
      return Request.CreateResponse(HttpStatusCode.BadRequest, "failed to delete Apartment/Room Data");
    }

  }
}