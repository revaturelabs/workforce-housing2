using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Workforce.Data.Housing.Soap.ServiceModels;

namespace Workforce.Data.Housing.Soap
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IGraceService" in both code and config file together.
    [ServiceContract]
    public interface IGraceService
    {

        /// <summary>
        /// GETS
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<HousingComplexDao>GetComplexes();

        [OperationContract]
        List<ApartmentDao> GetApartments();

        [OperationContract]
        List<HousingDataDao> GetHousingData();

        [OperationContract]
        List<StatusDao> GetStatuses();


        /// <summary>
        /// INSERTS
        /// </summary>
        /// <param name="newapt"></param>
        /// <returns></returns>
        [OperationContract]
        bool InsertApartment(ApartmentDao newapt);

        [OperationContract]
        bool InsertHousingData(HousingDataDao newhdata);

        [OperationContract]
        bool InsertHousingComplex(HousingComplexDao newhcomplex);

        [OperationContract]
        bool InsertStatus(StatusDao newstatus);

        /// <summary>
        /// UPDATES
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        bool UpdateApartment(ApartmentDao apt);

        [OperationContract]
        bool UpdateHousingData(HousingDataDao hdata);

        [OperationContract]
        bool UpdateHousingComplex(HousingComplexDao hcomplex);

        [OperationContract]
        bool UpdateStatus(StatusDao status);

        [OperationContract]
        bool DeleteApartment(ApartmentDao apt);

        [OperationContract]
        bool DeleteHousingData(HousingDataDao hdata);

        [OperationContract]
        bool DeleteHousingComplex(HousingComplexDao hcomplex);

        [OperationContract]
        bool DeleteStatus(StatusDao status);

    }
}
