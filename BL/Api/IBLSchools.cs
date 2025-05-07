//using Dal.Models;
using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;
namespace BL.Api
{
    public interface IBLSchools
    {
        List<BlSchool> GetSchools();
        BlSchool GetSchoolBySymbol(int symbol);
        BlSchool? GetSchoolBySName(string n);
        List<BlExpenditure>? GetExpendituresOfSchool(int s);
        BlSchool CastingToBl(School s);
        List<BlSchool> CastingToBl(List<School> list);
        bool Create(School newS);
        decimal SetCurrBudget(int SchoolS);

        decimal GetSumOfEpendituresOfSchool(string name);
        decimal GetDebtOfSchool(string name);

        void RemoveSchool(int sSymbol);



    }
}
