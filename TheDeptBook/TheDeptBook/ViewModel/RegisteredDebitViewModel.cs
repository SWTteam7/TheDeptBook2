using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheDeptBook.Model;

namespace TheDeptBook.ViewModel
{
   class RegisteredDebitViewModel
   {
      private DeptModel _deptModel;
      public RegisteredDebitViewModel(DeptModel deptModel)
      {
         _deptModel = deptModel;
      }
   }
}
