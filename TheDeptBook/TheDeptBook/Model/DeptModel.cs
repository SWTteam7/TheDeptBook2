using System;
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
     
  
        public List<DeptorObject> ListOfAllDeptors { get; set; }

        

   

        public DeptModel()
        {
            
            ListOfAllDeptors = new List<DeptorObject>();
        }

        public void AddNewDeptor(string name, double debit)
        {

            
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
                 deptor.DebitList.Add(d);
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
                 
                 foreach (DebitObject debit in deptor.DebitList)
                 {
                    double debitAmount = debit.Debit;
                    totaldebits += debitAmount;
                 }
               }
            }

           return totaldebits;
        }

       
  

    }
}