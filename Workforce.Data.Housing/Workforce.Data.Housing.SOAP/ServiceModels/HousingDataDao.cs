using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Workforce.Data.Housing.SOAP.ServiceModels
{
    /// <summary>
    /// This class defines the Housing Data Data Access Object and it's properties
    /// </summary>

        [DataContract]
    public class HousingDataDao
    {
        [DataMember]
        public int AssociateID { get; set; }
        [DataMember]
        public Nullable<int> RoomID { get; set; }
        [DataMember]
        public DateTime MoveInDate { get; set; }
        [DataMember]
        public DateTime MoveOutDate { get; set; }
        [DataMember]
        public int StatusID { get; set; }
    }
}