using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workforce.Logic.Housing2.Helpers;
using Workforce.Logic.Housing2.TransferModels;

namespace Workforce.Logic.Housing2.Domain.Helpers
{
   public class AssociateHelper
   {
      private readonly LogicHelper logicHelper = new LogicHelper();
      private readonly Consumers consumerHelper = new Consumers();

      /// <summary>
      /// this method inserts an assocaite into a room and increase the current capacity
      /// </summary>
      /// <param name="associate"></param>
      /// <returns></returns>
      public async Task<bool> InsertAssociateToRoom(InsertAssociateDto associate)
      {
         //FIND THE ASSOCIATE FROM A LIST OF ASSOCIATES
         AssociateDto assoc = (await consumerHelper.ConsumeAssociatesFromAPI()).Find(id => id.AssociateID.Equals(associate.AssociateId));
         //FIND THE APARTMENT
         ApartmentDto aptDto = (await logicHelper.ApartmentsGetAll()).Find(id => id.RoomID.Equals(associate.RoomId));

         List<HousingDataDto> tt = await logicHelper.HousingDataGetAll();

         HousingDataDto data = new HousingDataDto()
         {
            AssociateID = assoc.AssociateID,
            MoveInDate = associate.MoveInDate,
            MoveOutDate = associate.MoveOutDate,
            RoomID = associate.RoomId,
            StatusID = 1
         };

         if (aptDto.CurrentCapacity < aptDto.MaxCapacity)
         {
            aptDto.CurrentCapacity++;
         }
         else
         {
            return false;
         }

         bool passed = false;
         bool passed2 = false;

         if (tt.Exists(id => id.AssociateID.Equals(data.AssociateID)))
         {
            passed2 = await logicHelper.UpdateHousingData(data);
         }
         else
         {
            passed2 = await logicHelper.AddHousingData(data);
         }

         //bool passed2 = await logicHelper.AddHousingData(data);
         if (passed2)
         {
            passed = await logicHelper.UpdateApartment(aptDto);
         }

         //bool passed = await logicHelper.UpdateApartment(aptDto);
         //bool passed2 = await logicHelper.AddHousingData(data);

         return (passed && passed2);
      }

      /// <summary>
      /// this method removes an assocaite from a room and decrease the current capacity
      /// </summary>
      /// <param name="associate"></param>
      /// <returns></returns>
      public async Task<bool> RemoveAssocFromRoom(InsertAssociateDto associate)
      {
         //FIND THE ASSOCIATE FROM A LIST OF ASSOCIATES
         AssociateDto assoc = (await consumerHelper.ConsumeAssociatesFromAPI()).Find(id => id.AssociateID.Equals(associate.AssociateId));
         //FIND THE APARTMENT
         ApartmentDto aptDto = (await logicHelper.ApartmentsGetAll()).Find(id => id.RoomID.Equals(associate.RoomId));

         //FIND THE HousingData
         HousingDataDto data = (await logicHelper.HousingDataGetAll()).Find(id => id.AssociateID.Equals(associate.AssociateId));
         //update the status to 3  WHERE THREE MEANS TO DELETE
         data.StatusID = 3;
         if (aptDto.CurrentCapacity > 0)
         {
            aptDto.CurrentCapacity--;
         }
         else
         {
            return false;
         }

         data.RoomID = null;

         bool passed = await logicHelper.UpdateApartment(aptDto);
         // bool passed2 = await logicHelper.UpdateHousingData(data);
         bool passed3 = await logicHelper.UpdateHousingData(data);

         return (passed && passed3);
      }

      /// <summary>
      /// this method returns a list of all the associates consumed from felice that are roomless
      /// </summary>
      /// <returns></returns>
      public async Task<List<AssociateDto>> AssociatesGetRoomless()
      {
         List<AssociateDto> assDto = await consumerHelper.ConsumeAssociatesFromAPI();

         List<HousingDataDto> dataDto = await logicHelper.HousingDataGetAll();

         List<AssociateDto> returnList = new List<AssociateDto>();

         dataDto.RemoveAll(x => x.StatusID.Equals(3));

         foreach (var item in assDto)
         {
            if (!dataDto.Exists(assId => assId.AssociateID.Equals(item.AssociateID)))
            {
               returnList.Add(item);
            }
         }

         return returnList;
      }

      /// <summary>
      /// this method returns a list of all the associates consumed from felice that are inside a particular room
      /// </summary>
      /// <param name="associate"></param>
      /// <returns></returns>
      public async Task<List<AssociateDto>> AssociatesGetByApartment(InsertAssociateDto associate)
      {
         List<AssociateDto> assDto = await consumerHelper.ConsumeAssociatesFromAPI();
         //find all housingDatas with a given room id
         List<HousingDataDto> dataDto = (await logicHelper.HousingDataGetAll()).FindAll(x => x.RoomID.Equals(associate.RoomId));

         //now the above list has housingDatas with the same roomid and with different AssociateIds so we will return a list of all the
         //associate dtos were thier id is equal to the housing data


         dataDto.RemoveAll(x => x.StatusID.Equals(3));

         List<AssociateDto> returnList = new List<AssociateDto>();

         foreach (var item in assDto)
         {
            if (dataDto.Exists(x => x.AssociateID.Equals(item.AssociateID)))
            {
               returnList.Add(item);
            }

         }
         return returnList;
      }

      public async Task<bool> ChangeAssocToDifferentRoom(InsertAssociateDto associate)
      {
         throw new NotImplementedException();
      }
   }

}