using Dal.Api;
//using Dal.Models;
using BL.Api;
using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;
using Dal.Services;

namespace BL.Services
{
    public class BlUsersService : IBLUsers
    {
        IDalUsers dal;

        public BlUsersService(IDal data)
        {
            dal = data.Users;
        }

        public List<User> GetUsers() =>
             dal.GetUsers().ToList().OrderBy(e=>e.UserName).ToList();


        public User GetUserById(long id) =>
             GetUsers().ToList().Find(u => u.Id == id);


        public User GetUserByName(string name) =>
             GetUsers().ToList().Find(u => u.UserName.Equals(name));


        public List<User> GetUsersBySchoolSymbol(int symbol) =>
            GetUsers().ToList().FindAll(u => u.SchoolSymbol == symbol);


        //Casting to BL
        //public BlUser CastingToBl(User u)
        //{
        //    BlUser bls = new BlUser()
        //    {   
        //        Id = u.Id,
        //        UserName = u.UserName,
        //        SchoolSymbol = u.SchoolSymbol,    

        //    };
        //    return bls;
        //}

        //Casting a list to bl
        //public List<BlUser> CastingToBl(List<User> list)
        //{
        //    List<BlUser> bls = new List<BlUser>();

        //    foreach (User item in list)
        //    {
        //        bls.Add(CastingToBl(item));
        //    }

        //    return bls;
        //}


        public void RemoveUser(long id)
        {
            dal.RemoveUser(id);
        }

        public bool Create(User user)
        {
            try
            {
                dal.Create(user);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Bluser not create");
            }
        }
    }
}
