using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDeptBook.Model
{
    public interface IDeptModel
    {
        string Name { get; set; }
        double Debit { get; set; }
        DateTime Date { get; set; }

        Dictionary<string, List<Dictionary<DateTime, double>>> Depts { get; set; }
        List<string> Deptors { get; set; }
       List<Dictionary<string, double>> ListOfAllDeptors { get; set; }


        void AddNewDeptor(string name, double debit);
        void AddNewDebit(string name, double debit);

        Dictionary<string, double> GetDeptorAndTotalDebit(string name);

        void AllDeptors();
    }
}
