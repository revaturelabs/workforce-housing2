using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Workforce.Data.Housing.Soap.ServiceModels
{
    /// <summary>
    /// This class defines the Apartment Data Access Object and it's properties
    /// </summary>
    
    [DataContract]
    public class ApartmentDao
    {
        [DataMember]
        public int RoomID { get; set; }
        [DataMember]
        public int RoomNumber { get; set; }
        [DataMember]
        public int CurrentCapacity { get; set; }
        [DataMember]
        public int MaxCapacity { get; set; }
        [DataMember]
        public Nullable<int> GenderID { get; set; }
        [DataMember]
        public Nullable<int> HotelID { get; set; }
        [DataMember]
        public bool ActiveBit { get; set; }
    }
}