using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workforce.Logic.Housing2.TransferModels
{
   public class InsertAssociateDto
   {
      public int RoomId { get; set; }
      public int AssociateId { get; set; }
      public DateTime MoveInDate { get; set; }
      public DateTime MoveOutDate { get; set; }
   }
}