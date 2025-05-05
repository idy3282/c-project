//using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;
namespace Dal.Api
{
    public interface IDalExpenditures
    {
        List<Expenditure> GetExpenditures();

        Expenditure UpdateExpenditure(Expenditure expenditure, int id);
        bool Create(Expenditure expenditure);
        void RemoveExpenditure(int id);




    }
}
