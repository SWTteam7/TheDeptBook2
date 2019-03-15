using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TheDeptBook.Annotations;
using TheDeptBook.Model;

namespace TheDeptBook.ViewModel
{
   public class AddDeptorViewModel: INotifyPropertyChanged,IViewModel
   {
      private DeptModel _deptModel;
      private INavigateService _navigate;

      public event PropertyChangedEventHandler PropertyChanged;

      [NotifyPropertyChangedInvocator]
      protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
      {
         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }


      public AddDeptorViewModel(DeptModel deptModel, INavigateService nav)
      {
         _deptModel = deptModel;
         _navigate = nav;
      }

      public void Add(string name, double debit)
      {
          _deptModel.AddNewDebit(name,debit);
      }

      public void Save()
      {
          //pas?
      }
}
}
