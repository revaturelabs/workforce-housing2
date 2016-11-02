using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workforce.Data.Housing.Domain;
using Workforce.Data.Housing.Soap.ServiceModels;

namespace Workforce.Data.Housing.Soap.ServiceMapper
{
    public class EfMapper
    {

        private readonly MapperConfiguration HousingComplexMapper = new MapperConfiguration(g => g.CreateMap<HousingComplex, HousingComplexDao>().ReverseMap());
        private readonly MapperConfiguration ApartmentMapper = new MapperConfiguration(m => m.CreateMap<Apartment, ApartmentDao>().ReverseMap());
        private readonly MapperConfiguration HousingDataMapper = new MapperConfiguration(r => r.CreateMap<HousingData, HousingDataDao>().ReverseMap());
        private readonly MapperConfiguration StatusMapper = new MapperConfiguration(s => s.CreateMap<Status, StatusDao>().ReverseMap());


        /// <summary>
        /// these methods map the daos to the entity objects and vice versa
        /// </summary>
        /// <returns></returns>


        public HousingComplexDao MapToService(HousingComplex housing)
        {
            var mapper = HousingComplexMapper.CreateMapper();

            return mapper.Map<HousingComplexDao>(housing);
        }

        public HousingComplex MapToData(HousingComplexDao housing)
        {
            var mapper = HousingComplexMapper.CreateMapper();

            return mapper.Map<HousingComplex>(housing);
        }



        public ApartmentDao MapToService(Apartment apt)
        {
            var mapper = ApartmentMapper.CreateMapper();

            return mapper.Map<ApartmentDao>(apt);
        }

        public Apartment MapToData(ApartmentDao apt)
        {
            var mapper = ApartmentMapper.CreateMapper();

            return mapper.Map<Apartment>(apt);
        }



        public HousingDataDao MapToService(HousingData hdata)
        {
            var mapper = HousingDataMapper.CreateMapper();

            return mapper.Map<HousingDataDao>(hdata);
        }

        public HousingData MapToData(HousingDataDao hdata)
        {
            var mapper = HousingDataMapper.CreateMapper();

            return mapper.Map<HousingData>(hdata);
        }



        public StatusDao MapToService(Status status)
        {
            var mapper = StatusMapper.CreateMapper();

            return mapper.Map<StatusDao>(status);
        }

        public Status MapToData(StatusDao status)
        {
            var mapper = StatusMapper.CreateMapper();

            return mapper.Map<Status>(status);
        }
    }
}