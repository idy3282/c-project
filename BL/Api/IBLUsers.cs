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
    public interface IBLUsers
    {
        List<User> GetUsers();

        User GetUserById(long id);

        User GetUserByName(string name);

        List<User> GetUsersBySchoolSymbol(int symbol);

        //User CastingToBl(User user);

        //List<User> CastingToBl(List<User> l);
        bool Create(User user);
        void RemoveUser(long id);
    }
}
