
using BL.Models;
//using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;
namespace BL.Api
{
    public interface IBLSuppliers

    {
        List<BlSupplier> GetSuppliers();
        List<BlSupplier>? GetSuppliersForSchool(int schoolS);
        BlSupplier? GetSupplierByLicensedNum(int licensedNum);
        BlSupplier CastingToBl(Supplier s);
        List<BlSupplier> CastingToBl(List<Supplier> l);
        public void UpdateSupllier(Supplier s, int ln);
        decimal DebtForSupllier(string name);
        BlSupplier? GetSupplierByName(string n);
        decimal GeneralAmountForSupplier(Supplier s);
        bool Create(Supplier supplier);
        void RemoveSupplier(int ls);






    }
}
