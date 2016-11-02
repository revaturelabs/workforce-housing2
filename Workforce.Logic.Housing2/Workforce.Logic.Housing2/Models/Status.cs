using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workforce.Logic.Housing2.Models
{
   public class Status
   {
      //have a method here to mapToDao and mapToDto
      //Have a method here to validate both the DAO's and DTO's


      //private readonly GraceServiceClient f = new GraceServiceClient();
      private readonly MapperConfiguration statusMapper = new MapperConfiguration(m => m.CreateMap<StatusDao, StatusDto>().ReverseMap());


      private bool validate(IEnumerable<StatusDao> temp)
      {
         return true;
      }
      /// <summary>
      /// This method maps from a StatusDao to a StatusDto
      /// </summary>
      /// <param name="status"></param>
      /// <returns>StatusDto</returns> 
      public StatusDto MapToDto(StatusDao status)
      {
         var mapper = statusMapper.CreateMapper();
         return mapper.Map<StatusDto>(status);
      }

      /// <summary> 
      /// This method maps from a StatusDto to a StatusDao 
      /// </summary>
      /// <param name="status"></param>
      /// <returns>StatusDao</returns>
      public StatusDao MapToDao(StatusDto status)
      {
         var mapper = statusMapper.CreateMapper();
         return mapper.Map<StatusDao>(status);
      }
      /// <summary>
      /// This method recieves an IEnumerable<StatusDao>  and converts it
      /// into a list of List<StatusDto>
      /// </summary>
      /// <param name="daos"></param>
      /// <returns>List<StatusDto></returns>
      public List<StatusDto> getDtoList(IEnumerable<StatusDao> daos)
      {
         var stats = new List<StatusDto>();
         foreach (var item in daos)
         {
            var temp = MapToDto(item);
            stats.Add(temp);
         }
         return stats;
      }

   }
}