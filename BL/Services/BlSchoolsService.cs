using Dal.Api;
//using Dal.Models;
using BL.Api;
using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Common.Models;
using static Azure.Core.HttpHeader;

namespace BL.Services
{
    public class BlSchoolsService : IBLSchools
    {
        IDalSchools dal;
        IBLExpenditures exp;
        IBLUsers users;

        public BlSchoolsService(IDal data, IBLExpenditures exp, IBLUsers user)
        {
            dal = data.Schools;
            this.exp = exp;
            users = user;
        }

        public List<BlSchool> GetSchools() =>
               CastingToBl(dal.GetSchools().ToList());

        public BlSchool GetSchoolBySymbol(int s) =>
               GetSchools().Find(school => school.SchoolSymbol == s) ?? throw new Exception("sdfa");

        public BlSchool? GetSchoolBySName(string n) =>
               GetSchools().Find(school => school.SchoolName == n);

        public List<BlExpenditure>? GetExpendituresOfSchool(int s) =>
               GetSchoolBySymbol(s).Expenditures.ToList();

        //Casting to BL
        public BlSchool CastingToBl(School s)
        {
            s.Users.ToList().ForEach(school => Console.WriteLine(school));

            BlSchool bls = new BlSchool()
            {
                SchoolSymbol = s.SchoolSymbol,
                SchoolName = s.SchoolName,
                Budget = s.Budget,
                Expenditures = exp.CastingToBl(s.Expenditures.ToList()),

                //Users = s.Users.Select(x => new User() { Id = x.Id, SchoolSymbol = x.SchoolSymbol, UserName = x.UserName }).ToList(),
                //users.CastingToBl(s.Users.ToList()),
            };
            return bls;
        }
        //Casting a list to bl
        public List<BlSchool> CastingToBl(List<School> list)
        {
            List<BlSchool> bls = new List<BlSchool>();

            list.ForEach(l => bls.Add(CastingToBl(l)));

            return bls;
        }

        //קבלת תקציב נוכחי
        public decimal SetCurrBudget(int sSymbol)
        {
            BlSchool s = GetSchoolBySymbol(sSymbol) ?? throw new Exception("sdasd");
            decimal? f = (decimal)s.Budget - GetDebtOfSchool(s.SchoolName);
            return (decimal)(s.Budget - f);
        }

        //חוב מוסד
        public decimal GetDebtOfSchool(params string[] names)
        {
            decimal totalSum = 0;
            names.ToList().ForEach(school =>
            {
                BlSchool s = GetSchoolBySName(school) ?? throw new Exception();
                totalSum += (s.Expenditures.Sum(ss => ss.ExpenditureSum - ss.AmountPaid));
            });

            return totalSum;
            // decimal sum = 0;
            //BlSchool s = GetSchoolBySName(name)?? throw new Exception();
            //return s.Expenditures.Sum(ss => ss.ExpenditureSum - ss.AmountPaid);



            //s.Expenditures.ToList().ForEach(x =>
            //{ 
            //    sum += (x.ExpenditureSum - x.AmountPaid); }
            //);
            //return sum;
        }

        // סכום הוצאות  של מוסד מסוים
        public decimal GetSumOfEpendituresOfSchool(string name)
        {

            BlSchool s = GetSchoolBySName(name);
            return s.Expenditures.Sum(s => s.ExpenditureSum);


        }

        public void RemoveSchool(int sSymbol)
        {
            dal.RemoveSchool(sSymbol);
        }

        public decimal GetDebtOfSchool(string name)
        {
            throw new NotImplementedException();
        }
    }

}
