using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workforce.Logic.Housing2.HousingReference;
using Workforce.Logic.Housing2.TransferModels;

namespace Workforce.Logic.Housing2.Models
{
   public class D3AptCapacity
   {
      /// <summary>
      /// this method makes the JSON/XML model for the d3JS graph to consume
      /// </summary>
      /// <returns>Task<List<GraphAptCapacityDto>></returns>
      public async Task<List<GraphAptCapacityDto>> getNewModel()
      {
         HousingComplex mapper = new HousingComplex();
         List<GraphAptCapacityDto> returnGraph = new List<GraphAptCapacityDto>();
         foreach (var item in await houseService.GetComplexesAsync())
         {
            if (item.ActiveBit)
            {
               returnGraph.Add(
                 new GraphAptCapacityDto()
                 {
                    name = item.Name,
                    maxCapacity = await returnComplexMaxCap(mapper.MapToDto(item)),
                    currentCapacity = await returnComplexCurCap(mapper.MapToDto(item))

                 });
            }
         }
         return returnGraph;
      }

      private readonly GraceServiceClient houseService = new GraceServiceClient();

      /// <summary>
      /// method to give the max capacity of the given apartment 
      /// </summary>
      /// <param name="hotApt"></param>
      /// <returns>Task<int></returns>
      public async Task<int> returnComplexCurCap(HousingComplexDto hotApt)
      {
         int Total = 0;
         foreach (var item in await houseService.GetApartmentsAsync())
         {
            if (item.ActiveBit && (item.HotelID == hotApt.HotelID))
            {
               Total += item.CurrentCapacity;
            }
         }
         return Total;
      }

      /// <summary>
      /// method to give the current capacity of the given apartment complex
      /// </summary>
      /// <param name="hotApt"></param>
      /// <returns>Task<int></returns>
      public async Task<int> returnComplexMaxCap(HousingComplexDto hotApt)
      {
         int Total = 0;
         foreach (var item in await houseService.GetApartmentsAsync())
         {
            if (item.ActiveBit && (item.HotelID == hotApt.HotelID))
            {
               Total += item.MaxCapacity;
            }
         }
         return Total;
      }
   }
}