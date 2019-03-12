using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheDeptBook.ViewModel;

namespace TheDeptBook
{
   public class NavigateService: INavigateService
   {
      public void show(IViewModel viewModel)
      {
         if (viewModel is AddDeptorViewModel)
         {
            AddDeptor view = new AddDeptor();
            view.DataContext = viewModel;
            view.Show();
         }
         else if (viewModel is RegisteredDebitViewModel)
         {
            RegisteredDebits view = new RegisteredDebits();
            view.DataContext = viewModel;
            view.Show();
         }
      }
   }
}
