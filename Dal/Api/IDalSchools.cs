//using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;
namespace Dal.Api
{
    public interface IDalSchools
    {
        List<School> GetSchools();

        void UpdateSchool(School school, int s);

        bool Create(School school);

        
        void RemoveSchool(int sSymbol);
        //School GetSchoolBySName(string n);
    }
}
