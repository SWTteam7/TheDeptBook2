using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TheDeptBook.Model
{
    public class DeptModel
    {
        public string Name { get; set; }
        public double Debit { get;  set; }
        public DateTime Date { get; set; }

        public Dictionary<string, List<Dictionary<DateTime,double>>> Depts { get; set; }
        public List<string> Deptors { get; private set; }

       public List<Dictionary<string, double>> ListOfAllDeptors { get; set; }

   

        public DeptModel()
        {
            Deptors = new List<string>();
            Depts = new Dictionary<string, List<Dictionary<DateTime,double>>>();
        }

        public void AddNewDeptor(string name, double debit)
        {

            string deptor = name;

            var list = new List<Dictionary<DateTime,double>>();
            Deptors.Add(deptor);
            list.Add(new Dictionary<DateTime, double>{{DateTime.Now,debit}});
            Depts.Add(deptor, list);
            
      }

        public void AddNewDebit(string name, double debit)
        {   
            List<Dictionary<DateTime,double>> deptlist;
            Depts.TryGetValue(name, out deptlist);
            deptlist.Add(new Dictionary<DateTime, double>{{DateTime.Now, debit}});
        }

        public Dictionary<string, double> GetDeptorAnTotaldDebit(string name)
        {
            double totaldebits = 0;
            List<Dictionary<DateTime, double>> deptlist;
            Depts.TryGetValue(name, out deptlist);
            foreach (var dept in deptlist)
            {
                foreach (KeyValuePair<DateTime, double> date in dept)
                {
                    double debit = date.Value;
                    totaldebits += debit;
                }
            }
            Dictionary<string, double> Deptor = new Dictionary<string, double>{{name,totaldebits}};
            return Deptor;
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

       public void AllDeptors()
       {
          
          foreach (var d in Deptors)
          {

             ListOfAllDeptors.Add(GetDeptorAnTotaldDebit(d));
          }
       }
    }
}