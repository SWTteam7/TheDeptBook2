﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TheDeptBook.Annotations;
using TheDeptBook.Model;

namespace TheDeptBook.ViewModel
{
   class RegisteredDebitViewModel: INotifyPropertyChanged
   {
      private DeptModel _deptModel;
      public RegisteredDebitViewModel(DeptModel deptModel)
      {
         _deptModel = deptModel;
      }

      public event PropertyChangedEventHandler PropertyChanged;

      [NotifyPropertyChangedInvocator]
      protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
      {
         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }
   }
}
