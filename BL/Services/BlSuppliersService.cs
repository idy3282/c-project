using Dal.Api;
//using Dal.Models;
using BL.Api;
using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Cryptography;
using Common.Models;
namespace BL.Services
{
    public class BlSuppliersService : IBLSuppliers
    {
        IDalSuppliers dal;
        IBLExpenditures exp;
        IBLSchools schools;
        public BlSuppliersService(IDal data, IBLExpenditures exp, IBLSchools schools)
        {
            dal = data.Suppliers;
            this.exp = exp;
           this.schools = schools;
        }


        public List<BlSupplier> GetSuppliers() =>
             CastingToBl(dal.GetSuppliers().ToList());



        public BlSupplier? GetSupplierByName(string n) =>
             GetSuppliers().ToList().Find(s => s.SupplierName == n);

        public BlSupplier? GetSupplierByLicensedNum(int licensedNum) =>
             GetSuppliers().ToList().Find(s => s.LicensedNum == licensedNum);

     
        public List<BlSupplier>? GetSuppliersForSchool(int schoolS)//=>
        {
            
          
           return  (from a in GetSuppliers()
                     join e in schools.GetSchoolBySymbol(schoolS).Expenditures
                     on a.LicensedNum equals GetSupplierByName(e.SupplierName).LicensedNum 
                     select a).Distinct<BlSupplier>().ToList();

        }

        //Casting to BL
        public BlSupplier CastingToBl(Supplier s)
        {
            BlSupplier bls = new BlSupplier()
            {
                SupplierName = s.SupplierName,
                LicensedNum = s.LicensedNum,
                BankCode = s.BankCode,
                NumOfBankBranch = s.NumOfBankBranch,
                NumOfBankAccount = s.NumOfBankAccount,
                NameOfOwnerAccount = s.NameOfOwnerAccount,
                Expenditures =exp.CastingToBl(s.Expenditures.ToList()),
                PaymentForSupllier = GeneralAmountForSupplier(s),
                DebtForSupllier = DebtForSupllier(s.SupplierName),

            };
            return bls;
        }
        //Casting a list to bl
        public List<BlSupplier> CastingToBl(List<Supplier> list)
        {
            List<BlSupplier> bls = new List<BlSupplier>();

            foreach (Supplier item in list)
            {
                bls.Add(CastingToBl(item));
            }

            return bls;
        }

        public void UpdateSupllier(Supplier s, int ln) =>

            dal.UpdateSupllier(s, ln);


        //public void UpdatePayment(int sId ,decimal payment)
        //{
        //    Supplier supplier = dal.GetSupplierByLicensed(sId);

        //    BlSupplier bls = Casting(supplier, payment);

        //}

        //חישוב סכום חוב לספק מסוים
        public decimal DebtForSupllier(string name)
        {
            //BlSupplier s = GetSuppliers().ToList().Find(s=>s.SupplierName == name);
            Supplier s = dal.GetSuppliers().Find(s => s.SupplierName == name);
            decimal debt = 0;
            s.Expenditures.ToList().ForEach(x =>
            { debt += (x.ExpenditureSum - x.AmountPaid); });
            return debt;

            //decimal PaymentOfSupllier = (from ss in s.Expenditures  
            //                             where !ss.amountPaid == ss.ExpenditureSum 
            //                             select ss.ExpenditureSum 
            //                             ).Sum();


        }


        public decimal GeneralAmountForSupplier(Supplier s)
        {
            decimal generalAmount = 0;
            s.Expenditures.ToList().ForEach(x =>
            { generalAmount += x.ExpenditureSum; });
            return generalAmount;
        }

        public bool Create(Supplier supplier)
        {
            return dal.Create(supplier);
        }

        public void RemoveSupplier(int ls)
        {
            dal.RemoveSupplier(ls);
        }
    }
}
