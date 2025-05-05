using Dal.Api;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;
namespace Dal.Services
{
    public class DalUsersService : IDalUsers
    {
        dbcontext data;

        public DalUsersService(dbcontext data)
        {
            this.data = data;
        }

        public List<User> GetUsers()
        {
            return data.Users.ToList();
        }

        public void UpdateUser(User user, long id)
        {
            int index = GetUsers().ToList().FindIndex(u => u.Id == id);
            GetUsers()[index] = user;
            data.SaveChanges();
        }

        public bool Create(User user)
        {
            try
            {
                data.Users.Add(user);
                try
                {
                    data.SaveChanges();
                    return true;
                }
                catch
                {
                    data.Users.Local.Remove(user);
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("user didn't create");
            }
        }
        public void RemoveUser(long id)
        {
            try
            {
                var u = GetUsers().ToList().Find(u => u.Id == id);
                // להוסיף לכידת שגיאה
                data.Users.Remove(u);
                data.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("User didnt removed");

            }

        }


    }
}
