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
  public class StatusController : ApiController
  {
    private readonly LogicHelper logicHelper = new LogicHelper();
    /// <summary>
    /// CRUD: Read calls logicHelper to get all Apartments from service
    /// </summary>
    /// <returns>Task<HttpResponseMessage></returns>
    public async Task<HttpResponseMessage> Get()
    {
      return Request.CreateResponse(HttpStatusCode.OK, await logicHelper.StatusesGetAll());
    }

    /// <summary>
    /// post method for inserting new status
    /// </summary>
    /// <param name="newStatus"></param>
    /// <returns></returns>
    public async Task<HttpResponseMessage> Post([FromBody]StatusDto newStatus)
    {     
      if(await logicHelper.AddStatus(newStatus))
      {
        return Request.CreateResponse(HttpStatusCode.OK, "successful insert");
      }
      return Request.CreateResponse(HttpStatusCode.BadRequest, "failed to insert");
    }
  }
}
