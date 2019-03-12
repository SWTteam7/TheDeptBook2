using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TheDeptBook.Annotations;
using TheDeptBook.Model;
using System.Windows.Input;

namespace TheDeptBook.ViewModel
{
   public class MainWindowViewModel : INotifyPropertyChanged,IViewModel
   {
      private DeptModel _deptModel;
      private INavigateService _navigationService;

      public event PropertyChangedEventHandler PropertyChanged;

      [NotifyPropertyChangedInvocator]
      protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
      {
         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }

      public MainWindowViewModel(DeptModel deptModel, INavigateService navService)
      {
         _deptModel = deptModel;
         _navigationService = navService;
      }

      private ICommand _addDeptorCommand;

      public ICommand AddDeptorCommand
      {
         get
         {
            if (_addDeptorCommand == null)
            {
               _addDeptorCommand = new RelayCommand(OpenAddDeptor);
            }
            return _addDeptorCommand;
         }
        
      }

      private void OpenAddDeptor()
      {
         _navigationService.show(new AddDeptorViewModel(_deptModel, _navigationService));
      }


      private ICommand _showDepts;

      //public ICommand ShowDepts()
      //{

      //}

      

   }
}
