using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheDeptBook.Model;
using TheDeptBook.ViewModel;

namespace TheDeptBook
{
   public class ViewModelLocater
   {
      public MainWindowViewModel MainWindowViewModel
      {
         get { return new MainWindowViewModel(new DeptModel());}
      }

      public AddDeptorViewModel AddDeptorViewModel
      {
         get { return new AddDeptorViewModel(new DeptModel());}
      }

      public RegisteredDebitViewModel RegisteredDebitViewModel
      {
         get { return new RegisteredDebitViewModel(new DeptModel());}
      }
   }
}
