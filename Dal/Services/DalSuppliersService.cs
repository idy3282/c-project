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
    public class DalSuppliersService : IDalSuppliers
    {
        dbcontext data;

        public DalSuppliersService(dbcontext data)
        {
            this.data = data;
        }

        public List<Supplier> GetSuppliers()
        {
            return data.Suppliers.Include(e => e.Expenditures).ToList();
        }




        public void UpdateSupllier(Supplier s, int ln)
        {
            int index = GetSuppliers().ToList().FindIndex(s => s.LicensedNum == ln);
            GetSuppliers()[index] = s;
            data.SaveChanges();

        }

        public bool Create(Supplier supplier)
        {
            try
            {
                data.Suppliers.Add(supplier);
                try
                {
                    data.SaveChanges();
                }
                catch
                {
                    data.Suppliers.Local.Remove(supplier);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("supplier didn't create");
            }
        }



        public void RemoveSupplier(int ls)
        {
            try
            {
                var r = GetSuppliers().ToList().Find(s => s.LicensedNum == ls);
                data.Suppliers.Remove(r);
                data.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Supplier didnt removed");
            }

        }

        public Supplier? GetSupplierByName(string name)
        {
            return GetSuppliers().Find(s=> s.SupplierName == name);
        }

    }
}
