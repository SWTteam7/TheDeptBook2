using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
      private ObservableCollection<DeptorObject> DeptorsToShow = new ObservableCollection<DeptorObject>();
     

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
         
      }


      public ObservableCollection<DeptorObject> Deptors
      {
         get => DeptorsToShow;
         set
         {
            //DeptorsToShow = value;
            //OnPropertyChanged();
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
         _navigationService.Show(new AddDeptorViewModel(_deptModel, _navigationService));
      }


      private ICommand _registeredDebitCommand;

      public ICommand RegisteredDebitCommand
      {
         get { return _registeredDebitCommand ?? (_registeredDebitCommand = new RelayCommand(OpenRegistredDebits)); }
      }

      private void OpenRegistredDebits()
      {
         _navigationService.Show(new RegisteredDebitViewModel(_deptModel,_navigationService, SelectedItem));
      }

      private ICommand _updateCommand;

      public ICommand UpdateCommand
      {
         get { return _updateCommand ?? (_updateCommand = new RelayCommand(ShowDeptors)); }
      }

     
      public void ShowDeptors()
      {
         if (DeptorsToShow != null)
         {
            DeptorsToShow.Clear();
         }

         foreach (DeptorObject deptor in _deptModel.ListOfAllDeptors)
         {
            string name = deptor.Name;
            List<DebitObject> debits = deptor.DebitList;
            double totalDebit = _deptModel.GetTotalDebit(name);

            DeptorObject d = new DeptorObject(name,debits, totalDebit);

            DeptorsToShow.Add(d);
         }
         OnPropertyChanged("Deptors");

        
      }
   }
}
