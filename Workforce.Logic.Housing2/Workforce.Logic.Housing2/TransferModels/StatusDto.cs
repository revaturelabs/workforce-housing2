using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workforce.Logic.Housing2.TransferModels
{
   public class StatusDto
   {
      public int StatusID { get; set; }
      public string StatusColor { get; set; }
      public string StatusMessage { get; set; }
      public bool ActiveBit { get; set; }
   }
}