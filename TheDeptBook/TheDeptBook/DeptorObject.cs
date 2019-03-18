using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDeptBook
{
   public class DeptorObject
   {
      public string Name { get; set; }
      public List<DebitObject> DebtList { get; set; }

      public double TotalDebit { get; set; }
      public DeptorObject(string name, List<DebitObject> debtList,double totalDebit)
      {
         Name = name;
         DebtList = debtList;
         TotalDebit = totalDebit;
      }

   }
}
