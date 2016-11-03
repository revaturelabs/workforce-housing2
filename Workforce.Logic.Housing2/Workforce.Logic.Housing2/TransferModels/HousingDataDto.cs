using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workforce.Logic.Housing2.TransferModels
{
   public class HousingDataDto
   {

      public int AssociateID { get; set; }
      public Nullable<int> RoomID { get; set; }
      public DateTime MoveInDate { get; set; }
      public DateTime MoveOutDate { get; set; }
      public int StatusID { get; set; }

   }
}