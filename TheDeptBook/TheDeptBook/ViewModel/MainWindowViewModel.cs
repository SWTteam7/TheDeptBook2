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
      private readonly DeptModel _deptModel;
      private readonly INavigateService _navigationService;

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
         get { return _addDeptorCommand ?? (_addDeptorCommand = new RelayCommand(OpenAddDeptor)); }
        
      }

      private void OpenAddDeptor()
      {
         _navigationService.show(new AddDeptorViewModel(_deptModel, _navigationService));
      }


      private ICommand _registeredDebitCommand;

      public ICommand RegisteredDebitCommand
      {
         get { return _registeredDebitCommand ?? (_registeredDebitCommand = new RelayCommand(OpenRegistredDebits)); }
      }

      private void OpenRegistredDebits()
      {
         _navigationService.show(new RegisteredDebitViewModel(_deptModel,_navigationService));
      }

      private ICommand _showDepts;

      //public ICommand ShowDepts()
      //{

      //}

      public string Title { get; set; }

      public List<Tuple<string, double, DateTime>> Deptors { get; set; }


   }
}
