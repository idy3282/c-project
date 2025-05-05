using Dal.Api;
using Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;
namespace Dal.Services
{
    public class DalSchoolsService : IDalSchools
    {
        dbcontext data;

        public DalSchoolsService(dbcontext data)
        {
            this.data = data;
        }

        public List<School> GetSchools()
        {
            return data.Schools.Include(x => x.Expenditures).Include(t => t.Users).ToList();

        }

        public void UpdateSchool(School school, int sSymbol)
        {
            int index = GetSchools().ToList().FindIndex(s => s.SchoolSymbol == sSymbol);
            GetSchools()[index] = school;
            data.SaveChanges();
        }
        public bool Create(School school)
        {
            try
            {
                data.Schools.Add(school);
                data.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("school didn't create");
            }
        }



        public void RemoveSchool(int sSymbol)
        {
            try
            {
                var s = GetSchools().ToList().Find(s => s.SchoolSymbol == sSymbol);
                data.Schools.Remove(s);
                data.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("School didnt removed");

            }

        }

    }
}
