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

        
   
        List<DeptorObject> ListOfAllDeptors { get; set; }
        


        void AddNewDeptor(string name, double debit);
        void AddNewDebit(string name, double debit);
       

        double GetTotalDebit(string name);

    }
}
