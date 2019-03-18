using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TheDeptBook.ViewModel;

namespace TheDeptBook
{
   public interface INavigateService
   {
      void Show(IViewModel viewModel);
      void Close(IViewModel viewModel);
   }
}
