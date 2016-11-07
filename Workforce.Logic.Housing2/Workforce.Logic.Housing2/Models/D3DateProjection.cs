using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workforce.Logic.Housing2.Helpers;
using Workforce.Logic.Housing2.HousingReference;
using Workforce.Logic.Housing2.TransferModels;

namespace Workforce.Logic.Housing2.Models
{
   public class D3DateProjection
   {
      private readonly GraceServiceClient houseService = new GraceServiceClient();
      private readonly LogicHelper logicHelper = new LogicHelper();

      private readonly Consumers consumerHelper = new Consumers();

      /// <summary>
      /// this method returns the model needed for d3js projections
      /// </summary>
      /// <param name="projectionDate"></param>
      /// <returns></returns>
      public async Task<List<D3Projection>> getNewModel(DateTime projectionDate)
      {
         int totalMaxCapacity = 0;
         //int totalCurCapacity = 2;

         foreach (var item in await logicHelper.HousingComplexsGetActive())
         {
            totalMaxCapacity += await returnComplexMaxCap(item);
            //totalCurCapacity += await returnComplexCurCap(item);
         }

         List<D3Projection> returnList = new List<D3Projection>();
         for (int i = 0; i < 37; i++)
         {
            D3Projection temp = new D3Projection();
            temp.TotalMax = totalMaxCapacity;
            temp.Date = projectionDate.ToString("yyyy-MM-dd");
            //temp.CurrentCapacity = totalCurCapacity;
            //totalCurCapacity += 3;
            temp.CurrentCapacity = await findCurrCapDate(projectionDate);
            returnList.Add(temp);
            projectionDate = projectionDate.AddDays(1.0);
         }


         return returnList;
      }

      /// <summary>
      /// method to get the current capacity of a given date
      /// </summary>
      /// <param name="dateTime"></param>
      /// <returns></returns>
      private async Task<int> findCurrCapDate(DateTime dateTime)
      {
         int value = 0;
         //List<AssociateDto> assoc = await consumerHelper.ConsumeAssociatesFromAPI();
         //FIND THE APARTMENT

         List<HousingDataDto> dataList = await logicHelper.HousingDataGetAll();

         List<HousingDataDto> returnList = new List<HousingDataDto>();

         foreach (var item in dataList)
         {
            int b1 = (item.MoveInDate.CompareTo(dateTime));
            int b2 = (dateTime.CompareTo(item.MoveOutDate));

            if ((b1 == -1 || b1 == 0) && (b2 == 0 || b2 == 1))
            {
               returnList.Add(item);
            }

         }

         List<ApartmentDto> aptDto = await logicHelper.ApartmentsGetAll();

         foreach (var item in returnList)
         {
            if (item.RoomID != null)
            {
               ApartmentDto temp = aptDto.Find(id => id.RoomID.Equals(item.RoomID));
               value += temp.CurrentCapacity;
            }
         }


         return value;


      }
      /// <summary>
      /// this method returns the int value of the current capacity for the given complex
      /// </summary>
      /// <param name="hotApt"></param>
      /// <returns></returns>
      private async Task<int> returnComplexCurCap(HousingComplexDto hotApt)
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
      /// this method returns the int value of the max capacity for the given complex
      /// </summary>
      /// <param name="hotApt"></param>
      /// <returns></returns>
      private async Task<int> returnComplexMaxCap(HousingComplexDto hotApt)
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