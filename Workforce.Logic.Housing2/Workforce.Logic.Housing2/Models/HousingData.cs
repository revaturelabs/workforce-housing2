using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workforce.Logic.Housing2.Models
{
   public class HousingData
   {
      //have a method here to mapToDao and mapToDto
      //Have a method here to validate both the DAO's and DTO's



      //private readonly GraceServiceClient f = new GraceServiceClient();
      private readonly MapperConfiguration dataMapper = new MapperConfiguration(m => m.CreateMap<HousingDataDao, HousingDataDto>().ReverseMap());


      private bool validate(IEnumerable<HousingDataDao> temp)
      {
         return true;
      }
      /// <summary>
      /// This method maps from a HousingDataDao to a HousingDataDto
      /// </summary>
      /// <param name="data"></param>
      /// <returns>HousingDataDto</returns> 
      public HousingDataDto MapToDto(HousingDataDao data)
      {
         var mapper = dataMapper.CreateMapper();
         return mapper.Map<HousingDataDto>(data);
      }

      /// <summary>
      /// This method maps from a HousingDataDto to a HousingDataDao
      /// </summary>
      /// <param name="data"></param>
      /// <returns>HousingDataDao</returns>
      public HousingDataDao MapToDao(HousingDataDto data)
      {
         var mapper = dataMapper.CreateMapper();
         return mapper.Map<HousingDataDao>(data);
      }
      /// <summary>
      /// This method recieves an IEnumerable<HousgindataDao>  and converts it
      /// into a list of List<HousingDataDto>
      /// </summary>
      /// <param name="daos"></param>
      /// <returns>List<HousingDataDto></returns>
      public List<HousingDataDto> getDtoList(IEnumerable<HousingDataDao> daos)
      {
         var data = new List<HousingDataDto>();
         foreach (var item in daos)
         {
            var temp = MapToDto(item);
            data.Add(temp);
         }
         return data;
      }

   }
}
