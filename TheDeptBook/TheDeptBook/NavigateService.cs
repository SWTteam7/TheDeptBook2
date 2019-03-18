using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TheDeptBook.ViewModel;

namespace TheDeptBook
{
   public class NavigateService: INavigateService
   {
      private AddDeptor _addDeptorView;
      private RegisteredDebits _registeredDebits;
      public void Show(IViewModel viewModel)
      {
         if (viewModel is AddDeptorViewModel)
         {
            _addDeptorView = new AddDeptor();
            _addDeptorView.DataContext = viewModel;
            _addDeptorView.Show();
         }
         else if (viewModel is RegisteredDebitViewModel)
         {
            _registeredDebits = new RegisteredDebits();
            _registeredDebits.DataContext = viewModel;
            _registeredDebits.Show();
         }
      }

      public void Close(IViewModel viewModel)
      {
         if (viewModel is AddDeptorViewModel)
         {
            _addDeptorView.Close();
         }
         else if (viewModel is RegisteredDebitViewModel)
         {
            _registeredDebits.Close();
         }
        
      }
   }
}
