using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
      private DeptorObject Deptor;
      private ObservableCollection<DebitObject> DebitsToShow = new ObservableCollection<DebitObject>();

      public RegisteredDebitViewModel(IDeptModel deptModel,INavigateService nav, DeptorObject deptor)
      {
         _deptModel = deptModel;
         _navigate = nav;
         Deptor = deptor;
         ShowDebits();
      }

      public event PropertyChangedEventHandler PropertyChanged;

      [NotifyPropertyChangedInvocator]
      protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
      {
         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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



      public ObservableCollection<DebitObject> Debits
      {
         get => DebitsToShow;
         set
         {
            
         }
      }

     
      public void ShowDebits()
      {
         if (DebitsToShow != null)
         {
            DebitsToShow.Clear();
         }

         foreach (DebitObject debit in Deptor.DebtList)
         {
            DebitsToShow.Add(debit);
         }
         OnPropertyChanged("Debits");

      }



      private ICommand _addDebitCommand;

      public ICommand AddDebitCommand
      {
          get { return _addDebitCommand ?? (_addDebitCommand = new RelayCommand(AddValue)); }

      }


      public void AddValue()
      {
         _deptModel.AddNewDebit(Deptor.Name,Debit);
         ShowDebits();
         Debit = 0.0;
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
 