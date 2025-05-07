using BL.Api;
using BL.Models;
using Dal.Api;
//using Dal.Models;
using System.Numerics;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Common.Models;
namespace BL.Services
{
    public class BlExpendituresService : IBLExpenditures
    {
        IDalExpenditures dal;
        //IBLCategories ctg;
        IDalCategories ctg;
        IDalSuppliers supp;
        public BlExpendituresService(IDal data ,IDal supp,IBLCategories ctg)
        {

            dal = data.Expenditures;
            this.supp= supp.Suppliers;
         //   data.Categories
            this.ctg = data.Categories ;
        }

        public List<BlExpenditure> GetExpenditures()
        {
            /*  List<Expenditure> l = dal.GetExpenditures().ToList(); */
          /*  List<BlExpenditure> l = CastingToBl(dal.GetExpenditures().ToList()).OrderByDescending(c => c.Date).ToList();
            l.Reverse();
            l.ToList();*/

            return CastingToBl(dal.GetExpenditures().ToList()).OrderByDescending(c => c.Date).ToList();

        }

        public BlExpenditure GetExpenditureById(int id)
        {
            int index = GetExpenditures().ToList().FindIndex(e => e.Id == id);
            return GetExpenditures()[index];
        }


        //casting to BL
        public  BlExpenditure CastingToBl(Expenditure e)
        {
            BlExpenditure bls = new BlExpenditure()
            {
                Id = e.Id,
                SchoolSymbol = e.SchoolSymbol,
                ExpenditureSum = e.ExpenditureSum,
                CategoryName = ctg.GetCategories().Result.Find(c=>c.CategoryId == e.CategoryId).CategoryName,
                SupplierName = e.SupplierNumNavigation != null ? e.SupplierNumNavigation.SupplierName : "jj",
                Date = e.Date,
                OrdererName = e.OrdererName,
                InvoiceNum = e.InvoiceNum,
                IsAccepted = e.IsAccepted,
                AmountPaid = e.AmountPaid,
                RemainToPay = e.ExpenditureSum - e.AmountPaid
                

            };
            return bls;
        }

        public  List<BlExpenditure> CastingToBl(List<Expenditure> list)
        {
            List<BlExpenditure> bls = new List<BlExpenditure>();

            foreach (Expenditure item in list)
            {
                bls.Add(CastingToBl(item));
            }

            return bls;
        }
        //המרה לדל
        public  Expenditure CastingToDal(BlExpenditure blExpenditure)
        {
            Expenditure expenditure = new Expenditure()
            {
                SchoolSymbol = blExpenditure.SchoolSymbol,
                ExpenditureSum = blExpenditure.ExpenditureSum,
                CategoryId = ctg.GetCategories().Result.Find(c=>c.CategoryName==blExpenditure.CategoryName).CategoryId ,
                SupplierNum = supp.GetSupplierByName (blExpenditure.SupplierName).LicensedNum ,
                Date = blExpenditure.Date,
                OrdererName = blExpenditure.OrdererName,
                InvoiceNum = blExpenditure.InvoiceNum,
                IsAccepted = blExpenditure.IsAccepted,
                AmountPaid = blExpenditure.AmountPaid,
            };
            return expenditure;
        }
        public bool Create(BlExpenditure expenditure)
        {
            try
            {
                // בודק תקינות למשל אולי 
                dal.Create(CastingToDal(expenditure));
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("BlExpenditure not create");
            }
        }

        //
        //public decimal GetPaimentBySupllierId(int sId)
        //{
        //    List<Expenditure> l = dal.GetExpenditures();
        //    decimal sum = (from b in l
        //                   where b.SupplierNum == sId && !b.IsPaid
        //                   select b.ExpenditureSum).Sum();

        //    return sum;
        //}
        //חישוב סכום כולל של הוצאות
        //public decimal GetUsingBudget(int SchoolSymbol)
        //{
        //    List<Expenditure> l = dal.GetExpenditures();
        //    decimal usingBudget = (from e in l
        //                   where e.SchoolSymbol == SchoolSymbol  && e.IsPaid
        //                   select e.ExpenditureSum).Sum();

        //    return usingBudget;
        //}

        //חישוב סכום כולל בקטגוריה מסוימת
        public decimal GetSumOfCategory(int categoryId)
        {
            List<Expenditure> l = dal.GetExpenditures();
            decimal sumOgCategory = (from e in l
                                     where e.CategoryId == categoryId
                                     select e.ExpenditureSum).Sum();

            return sumOgCategory;
        }
        //lllllllllllllllll
        public decimal GetPaimentBySupllierId(int sId)
        {
            throw new NotImplementedException();
        }

        public decimal GetUsingBudget(int SchoolSymbol)
        {
            throw new NotImplementedException();
        }

        public void RemoveExpenditures(int ls)
        {
            dal.RemoveExpenditure(ls);
        }

        public Expenditure UpdateExpenditure(Expenditure expenditur, int id)
        {
            return dal.UpdateExpenditure(expenditur, id);
        }

        bool IBLExpenditures.RemoveExpenditures(int ls)
        {
            throw new NotImplementedException();
        }


        ////חישוב סכום כולל למוסד מסוים
        //IBL b = new BlSchool();
        //public decimal GetTotalSumOfSchool(string sName)
        //{
        //    School s = b.Schools.GetSchoolBySName(sName);
        //}


    }
}
