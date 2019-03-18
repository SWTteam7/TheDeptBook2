using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDeptBook
{
   public class DebitObject
   {
      public DateTime Dt { get; set; }
      public double Debit { get; set; }
      public DebitObject(DateTime dt, double debit)
      {
         Dt = dt;
         Debit = debit;
      }
   }
}
