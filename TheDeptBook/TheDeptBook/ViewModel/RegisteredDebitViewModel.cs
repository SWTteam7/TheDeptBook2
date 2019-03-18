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
      private string _selectedItem;

      public RegisteredDebitViewModel(DeptModel deptModel,INavigateService nav, string selectedItem)
      {
         _deptModel = deptModel;
         _navigate = nav;
         _selectedItem = selectedItem;
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

      public DateTime Date
      {
          get => _deptModel.Date;
          set
          {
              _deptModel.Date = value;
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

      public Dictionary<string, List<Dictionary<DateTime,double>>> Depts
      {
          get => _deptModel.Depts;
          set
          {
              _deptModel.Depts = value;
              OnPropertyChanged();
          }
      }

      private ICommand _addDebitCommand;

      public ICommand AddDeptorCommand
      {
          get { return _addDebitCommand ?? (_addDebitCommand = new RelayCommand(AddValue)); }

      }


        public void ShowRegistredDepts(string name)
      {
          //List<double> deptlist;
          //_deptModel.Depts.TryGetValue(name, out deptlist);
          //vis deptlist i listview

      }

      public void AddValue()
      {

         List<Dictionary<DateTime, double>> ListdateValue = new List<Dictionary<DateTime, double>>();
         Dictionary<DateTime, double> dateValue=new Dictionary<DateTime, double>();

          //get name fra der hvor der er klikket på main
          _deptModel.AddNewDebit(Name, Debit);

         dateValue.Add(Date,Debit);
         ListdateValue.Add(dateValue);

         Depts.Add(Name,ListdateValue);
      }

      private ICommand _closeCommand;

      public ICommand CloseCommand
      {
         get
         {
            if (_closeCommand == null)
            {
               _closeCommand = new RelayCommand(CloseAddDeptor);

            }

            return _closeCommand;
         }
      }


      private void CloseAddDeptor()
      {
         _navigate.close(this);
      }
   }
}
 