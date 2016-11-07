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
  public class HousingComplexController : ApiController
  {
    private readonly LogicHelper logicHelper = new LogicHelper();

    /// <summary>
    /// CRUD: Read calls logicHelper to get all housingComplexes from service
    /// </summary>
    /// <returns>Task<HttpResponseMessage></returns>
    public async Task<HttpResponseMessage> Get()//[FromUri] bool getActive)
    {
      bool getActive = true;
      if (getActive)
      {
        return Request.CreateResponse(HttpStatusCode.OK, await logicHelper.HousingComplexsGetActive());
      }
      return Request.CreateResponse(HttpStatusCode.OK, await logicHelper.HousingComplexsGetAll());
    }

    /// <summary>
    /// post method to insert a new complex
    /// </summary>
    /// <param name="newHousingComDto"></param>
    /// <returns></returns>
    public async Task<HttpResponseMessage> Post([FromBody]HousingComplexDto newHousingComDto)
    {
      newHousingComDto.ActiveBit = true;
      if (await logicHelper.AddHousingComplex(newHousingComDto))
      {
        return Request.CreateResponse(HttpStatusCode.OK, "successful insert");
      }
      return Request.CreateResponse(HttpStatusCode.OK, "failed to insert");
    }

    /// <summary>
    /// put method for HousingComplex
    /// </summary>
    /// <param name="complex"></param>
    /// <returns></returns>
    public async Task<HttpResponseMessage> Put([FromBody]HousingComplexDto complex)
    {
      if (await logicHelper.UpdateHousingComplex(complex))
      {
        return Request.CreateResponse(HttpStatusCode.OK, "successful insert");
      }
      return Request.CreateResponse(HttpStatusCode.OK, "failed to insert");
    }
    /// <summary>
    /// Delete method for Housing Complex
    /// </summary>
    /// <param name="complex"></param>
    /// <returns></returns>
    public async Task<HttpResponseMessage> Delete([FromBody]HousingComplexDto complex)
    {
      if (await logicHelper.DeleteComplex(complex))
      {
        return Request.CreateResponse(HttpStatusCode.OK, "successful insert");
      }
      return Request.CreateResponse(HttpStatusCode.OK, "failed to insert");
    }
  }
}
