using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Workforce.Logic.Domain.TransferModels.Dtos;

namespace Workforce.Logic.Domain.Helpers
{
  public class Consumers
  {

    /// <summary>
    /// this method consumes the associates from project Felice API
    /// </summary>
    /// <returns></returns>
    public async Task<List<AssociateDto>> ConsumeAssociatesFromAPI()
    {
      using (var client = new HttpClient())
      {
        // New code:
        client.BaseAddress = new Uri("http://ec2-54-175-5-94.compute-1.amazonaws.com/workforce-associate-rest/"); 
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        HttpResponseMessage response = await client.GetAsync("api/associate/1");
        List<AssociateDto> assoc = new List<AssociateDto>();
        if (response.IsSuccessStatusCode)
        {


          string holdingString = await response.Content.ReadAsStringAsync();
          assoc = JsonConvert.DeserializeObject<List<AssociateDto>>(holdingString);
        }

        return assoc;
      }
    }
  }
}