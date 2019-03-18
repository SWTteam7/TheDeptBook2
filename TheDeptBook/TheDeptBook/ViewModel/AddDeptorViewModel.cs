using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TheDeptBook.Annotations;
using TheDeptBook.Model;

namespace TheDeptBook.ViewModel
{
   public class AddDeptorViewModel: INotifyPropertyChanged,IViewModel
   {
      private IDeptModel _deptModel;
      private INavigateService _navigate;

      public event PropertyChangedEventHandler PropertyChanged;

      [NotifyPropertyChangedInvocator]
      protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
      {
         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }


      public AddDeptorViewModel(IDeptModel deptModel, INavigateService nav)
      {
         _deptModel = deptModel;
         _navigate = nav;
      }

      public string Name
      {
         get => _deptModel.Name;
         set
        {
            if (value!=_deptModel.Name)
            {
               _deptModel.Name = value;
               OnPropertyChanged();
            }
         }
      }

      public double InitValue
      {
         get => _deptModel.Debit;
         set
         {
            if (value != _deptModel.Debit)
            {
               _deptModel.Debit = value;
               OnPropertyChanged();
               
            }
         }
      }


      private ICommand _saveDeptorCommand;

      public ICommand SaveDeptorCommand
      {
         get
         {
            if (_saveDeptorCommand == null)
            {
               _saveDeptorCommand=new RelayCommand(SaveDeptor);
            }

            return _saveDeptorCommand;
         }
         
      }

      private void SaveDeptor()
      {
         _deptModel.AddNewDeptor(Name,InitValue);
         CloseAddDeptor();
         
      }

      private ICommand _closeCommand;

      public ICommand CloseCommand
      {
         get
         {
            if (_closeCommand == null)
            {
               _closeCommand=new RelayCommand(CloseAddDeptor);

            }

            return _closeCommand;
         }
      }

     
      private void CloseAddDeptor()
      {
         _navigate.Close(this);
         Name = "";
         InitValue = 0.0;
      }

   }
}
