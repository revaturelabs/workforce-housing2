using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Workforce.Data.Housing.Soap.ServiceModels
{
    /// <summary>
    /// This class defines the Status Data Access Object and it's properties
    /// </summary>
    [DataContract]
    public class StatusDao
    {
        [DataMember]
        public int StatusID { get; set; }

        [DataMember]
        public string StatusColor { get; set; }

        [DataMember]
        public string StatusMessage { get; set; }
    }
}