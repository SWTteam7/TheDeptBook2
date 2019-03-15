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

      public string Name
      {
          get => _deptModel.Name;
          set
          {
              _deptModel.Name = value;
              OnPropertyChanged();
          }
      }

      public double Debit
      {
          get => _deptModel.Debit;
          set
          {
              _deptModel.Debit = value;
              OnPropertyChanged();
          }
      }

      public Dictionary<string, List<double>> Depts
      {
          get => _deptModel.Depts;
          set
          {
              _deptModel.Depts = value;
              OnPropertyChanged();
          }
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

       public ICommand ShowDepts()
       {
         get { return _showDepts ?? (_showDepts = new RelayCommand(GetDepts)); } //ved ikke hvorfor det her ikke virker

       }
       private void GetDepts()
       {
           
           Depts =_deptModel.Depts; //det her tror jeg ikke virker for Depts er netop bare den liste???
           OnPropertyChanged("Depts");
       }

        public string Title { get; set; }

    


   }
}
