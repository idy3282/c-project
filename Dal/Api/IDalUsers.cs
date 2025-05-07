using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Dal.Models;
using Common.Models;
namespace Dal.Api
{
    public interface IDalUsers
    {
        
        List<User> GetUsers();

        void UpdateUser(User user, long id);
        bool Create(User user);
        void RemoveUser(long id);





    }
}
