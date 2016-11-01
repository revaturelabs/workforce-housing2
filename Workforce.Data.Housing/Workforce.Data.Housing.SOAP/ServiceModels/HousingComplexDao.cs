using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Workforce.Data.Housing.SOAP.ServiceModels
{
    /// <summary>
    /// This class defines the Housing Complex Data Access Object and it's properties
    /// </summary>
    [DataContract]
    public class HousingComplexDao
    {
        [DataMember]
        public int HotelID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public bool IsHotel { get; set; }
        [DataMember]
        public string PhoneNumber { get; set; }
        [DataMember]
        public bool ActiveBit { get; set; }
    }
}