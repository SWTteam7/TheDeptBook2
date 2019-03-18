﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TheDeptBook.Model
{
    public class DeptModel: IDeptModel
    {
        public string Name { get; set; }
        public double Debit { get;  set; }
     
        public List<string> DeptorsNames { get;  set; }
        public List<DeptorObject> ListOfAllDeptors { get; set; }

        

   

        public DeptModel()
        {
            DeptorsNames = new List<string>();
            ListOfAllDeptors = new List<DeptorObject>();
           List<DebitObject> d = new List<DebitObject>();
           d.Add(new DebitObject(DateTime.Now,12));
           d.Add(new DebitObject(DateTime.Now,100));
           ListOfAllDeptors.Add(new DeptorObject("Hans",d,0));
           
        }

        public void AddNewDeptor(string name, double debit)
        {

            DeptorsNames.Add(name);
            DebitObject d = new DebitObject(DateTime.Now,debit);
            List<DebitObject> debitList = new List<DebitObject>();
            debitList.Add(d);
           
            DeptorObject deptor = new DeptorObject(name, debitList,0);

            ListOfAllDeptors.Add(deptor);
      }

        public void AddNewDebit(string name, double debit)
        {

           foreach (DeptorObject deptor in ListOfAllDeptors)
           {
              if (deptor.Name == name)
              {
                 DebitObject d= new DebitObject(DateTime.Now, debit);
                 deptor.DebtList.Add(d);
              }
           }
        }

        public double GetTotalDebit(string name)
        {
           double totaldebits = 0.0;

            foreach (DeptorObject deptor in ListOfAllDeptors)
            {
              
               if (deptor.Name == name)
               {
                 
                 foreach (DebitObject debit in deptor.DebtList)
                 {
                    double debitAmount = debit.Debit;
                    totaldebits += debitAmount;
                 }
               }
            }

           return totaldebits;
        }

       

        //public string GetDeptor(string name)
        //{
        //    string wanteddeptor = "";
        //    foreach (var deptor in Deptors)
        //    {
        //        if (deptor == name)
        //        {
        //            wanteddeptor = deptor;
        //        }
        //        else
        //            wanteddeptor = "The wanted deptor was not found";
        //    }
        //    return wanteddeptor;

        //}

    }
}