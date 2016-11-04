using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workforce.Logic.Housing2.HousingReference;
using Workforce.Logic.Housing2.TransferModels;

namespace Workforce.Logic.Housing2.Models
{
   public class Apartment
   {
      //have a method here to mapToDao and mapToDto
      //Have a method here to validate both the DAO's and DTO's

      private readonly GraceServiceClient houseService = new GraceServiceClient();
      private readonly MapperConfiguration apartmentMapper = new MapperConfiguration(m => m.CreateMap<ApartmentDao, ApartmentDto>().ReverseMap());

      /// <summary>
      /// this method validates the dto but is not implemented yet
      /// </summary>
      /// <param name="temp"></param>
      /// <returns></returns>
      private bool validate(IEnumerable<ApartmentDto> temp)
      {

         return true;
      }



      #region methods to map a single dao-dto  dto-dao
      /// <summary>
      /// This method maps from a ApartmentDao to a ApartmentDto
      /// </summary>
      /// <param name="apt"></param>
      /// <returns>ApartmentDto</returns>
      public ApartmentDto MapToDto(ApartmentDao apt)
      {

         var mapper = apartmentMapper.CreateMapper();
         return mapper.Map<ApartmentDto>(apt);
      }
      /// <summary>
      /// This method maps from a ApartmentDto to a ApartmentDao
      /// </summary>
      /// <param name="apt"></param>
      /// <returns>ApartmentDao</returns>
      public ApartmentDao MapToDao(ApartmentDto apt)
      {
         var mapper = apartmentMapper.CreateMapper();
         return mapper.Map<ApartmentDao>(apt);
      }
      #endregion

      #region convert list dto-dao dto-dao with mapping
      /// <summary>
      /// This method recieves an IEnumerable<ApartmentDto>  and maps it
      /// into a list of List<ApartmentDao>
      /// </summary>
      /// <param name="dtos"></param>
      /// <returns>List<ApartmentDao></returns>
      public List<ApartmentDao> getDaoList(IEnumerable<ApartmentDto> dtos)
      {
         var apts = new List<ApartmentDao>();
         foreach (var item in dtos)
         {
            var temp = MapToDao(item);
            apts.Add(temp);
         }
         return apts;
      }

      /// <summary>
      /// This method recieves an IEnumerable<ApartmentDao>  and maps it
      /// into a list of List<ApartmentDto>
      /// </summary>
      /// <param name="daos"></param>
      /// <returns>List<ApartmentDto></returns>
      public List<ApartmentDto> getDtoList(IEnumerable<ApartmentDao> daos)
      {
         var apts = new List<ApartmentDto>();
         foreach (var item in daos)
         {
            var temp = MapToDto(item);
            apts.Add(temp);
         }
         return apts;
      }


      /// <summary>
      /// this method converts a list of all DAOs into dtos where active bit is true
      /// </summary>
      /// <param name="daos"></param>
      /// <returns></returns>
      public List<ApartmentDto> getActiveDtoList(IEnumerable<ApartmentDao> daos)
      {
         var apts = new List<ApartmentDto>();
         foreach (var item in daos)
         {
            if (item.ActiveBit)
            {
               var temp = MapToDto(item);
               apts.Add(temp);
            }
         }
         return apts;
      }
      #endregion
   }
}