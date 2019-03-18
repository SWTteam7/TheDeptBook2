using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TheDeptBook.Annotations;
using TheDeptBook.Model;

namespace TheDeptBook.ViewModel
{
   public class RegisteredDebitViewModel: INotifyPropertyChanged,IViewModel
   {
      private IDeptModel _deptModel;
      private INavigateService _navigate;
      public RegisteredDebitViewModel(DeptModel deptModel,INavigateService nav)
      {
         _deptModel = deptModel;
         _navigate = nav;
      }

      public event PropertyChangedEventHandler PropertyChanged;

      [NotifyPropertyChangedInvocator]
      protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
      {
         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
          
      }

        public void ShowRegistredDepts(string name)
      {
          List<double> deptlist;
          _deptModel.Depts.TryGetValue(name, out deptlist);
          //vis deptlist i listview

      }

      public void AddValue(double debit)
      {
          string namefromview="";
          //get name fra der hvor der er klikket på main
          _deptModel.AddNewDebit(namefromview, debit);
      }
   }
}
 