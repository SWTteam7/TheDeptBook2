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
        public double Debit { get;  set; }

        public Dictionary<string, List<double>> Depts { get; set; }
        public List<string> Deptors { get; private set; }

        public DeptModel()
        {
            Deptors = new List<string>();
            Depts = new Dictionary<string, List<double>>();
        }

        public void AddNewDeptor(string name)
        {

            string deptor = name;

            Deptors.Add(deptor);
            Depts.Add(deptor, new List<double>());
        }

        public void AddNewDebit(string name, double debit)
        {
            List<double> deptlist;
            Depts.TryGetValue(name, out deptlist);
            deptlist.Add(debit);
        }

        public double GetDebits(string name)
        {
            double totaldebits = 0;
            List<double> deptlist;
            Depts.TryGetValue(name, out deptlist);
            foreach (var dept in deptlist)
            {
                totaldebits += dept;
            }
            return totaldebits;
        }

        public string GetDeptor(string name)
        {
            string wanteddeptor = "";
            foreach (var deptor in Deptors)
            {
                if (deptor == name)
                {
                    wanteddeptor = deptor;
                }
                else
                    wanteddeptor = "The wanted deptor was not found";
            }
            return wanteddeptor;

        }
    }
}