using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDeptBook.Model
{
   public class DeptModel
   {    
        public string Name { get; set; }
        public double Debit { get; set; }
        public DateTime Date{ get; set; }

        private List<double> debits;
        private List<Tuple<string, double, DateTime>> deptors;

        public void AddNewDeptor(string name, double debit)
        {
            DateTime date = DateTime.Now;
            
            Tuple<string, double, DateTime> deptor = new Tuple<string, double, DateTime>(name, debit,date);

            deptors.Add(deptor);
        }

        public List<double> GetDebits(string name)
        { 
            foreach(var item in deptors)
            {
                if (item.Item1 == name)
                {
                   debits.Add(item.Item2);
                }
            }
            return debits;
        }
        public double CalculateDept(List<string> deptor)
        {
            foreach (var name in deptor)
            {
               List<double> debits = GetDebits(name);
             
            }
            return debits.Sum();
        }
   }
}