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
      private readonly IDeptModel _deptModel;
      private readonly INavigateService _navigationService;
     

      public event PropertyChangedEventHandler PropertyChanged;

      [NotifyPropertyChangedInvocator]
      protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
      {
         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }

      public MainWindowViewModel(IDeptModel deptModel, INavigateService navService)
      {
         _deptModel = deptModel;
         _navigationService = navService;
         Dictionary<string, double> dept=new Dictionary<string, double>();
         dept.Add("Emma",25.0);
         dept.Add("Christiane Nørkjær Svensen",-100);

         
         List<Dictionary<string, double>> bla = new List<Dictionary<string, double>>();
         bla.Add(dept);

         Deptors = bla;
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

      public List<Dictionary<string, double>> Deptors
      {
         get => _deptModel.ListOfAllDeptors;
         set
         {
            _deptModel.ListOfAllDeptors = value;
            OnPropertyChanged();
         }

      }

      public string SelectedItem { get; set; }
      

      
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
         _navigationService.show(new RegisteredDebitViewModel(_deptModel,_navigationService, SelectedItem));
      }

      //private ICommand _showDepts;

      // public ICommand ShowDepts
      // {
      //   get {return _showDepts ?? (_showDepts = new RelayCommand(GetDepts));}

      // }
       private void GetDepts()
       {
           var Depts =_deptModel.Depts;
           OnPropertyChanged("Depts");
       }

       

    


   }
}
