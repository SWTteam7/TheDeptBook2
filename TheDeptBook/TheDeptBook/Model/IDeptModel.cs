using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDeptBook.Model
{
    public interface IDeptModel
    {
        void AddNewDeptor(string name, double debit);
        void AddNewDebit(string name, double debit);

        Dictionary<string, double> GetDeptorAndTotalDebit(string name);

        void AllDeptors();
    }
}
