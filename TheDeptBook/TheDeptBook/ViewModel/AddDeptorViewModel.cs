using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheDeptBook.Model;

namespace TheDeptBook.ViewModel
{
   class AddDeptorViewModel
   {
      private DeptModel _deptModel;
      public AddDeptorViewModel(DeptModel deptModel)
      {
         _deptModel = deptModel;
      }
   }
}
