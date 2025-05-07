using BL.Models;
//using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;
namespace BL.Api
{
    public interface IBLExpenditures
    {

        List<BlExpenditure> GetExpenditures();

        BlExpenditure GetExpenditureById(int id);

        decimal GetPaimentBySupllierId(int sId);

        decimal GetUsingBudget(int SchoolSymbol);
        decimal GetSumOfCategory(int categoryId);

        List<BlExpenditure> CastingToBl(List<Expenditure> list);

       BlExpenditure CastingToBl(Expenditure e);
        Expenditure UpdateExpenditure(Expenditure Expenditure, int id);
        bool Create(BlExpenditure expenditure);
        bool RemoveExpenditures(int ls);


    }
}
