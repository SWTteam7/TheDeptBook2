using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheDeptBook.ViewModel;

namespace TheDeptBook
{
   public interface INavigateService
   {
      void show(IViewModel viewModel);
   }
}
