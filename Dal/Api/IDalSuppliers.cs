//using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;
namespace Dal.Api
{
    public interface IDalSuppliers
    {
        List<Supplier> GetSuppliers();

        void UpdateSupllier(Supplier s, int ln);
        bool Create(Supplier supplier);

        void RemoveSupplier(int ls);

        Supplier? GetSupplierByName(string name);













    }
}
