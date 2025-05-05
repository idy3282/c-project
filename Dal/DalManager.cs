using Dal.Api;
using Dal.Models;
using Dal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class DalManager : IDal
    {
        public IDalUsers Users { get; }

        public IDalExpenditures Expenditures { get; }

        public IDalSchools Schools { get; }

        public IDalSuppliers Suppliers { get; }

        public IDalCategories Categories { get; }

        public DalManager()
        {
            dbcontext data = new dbcontext();

            Categories = new DalCategoriesService(data);
            Expenditures = new DalExpendituresService(data);
            Suppliers = new DalSuppliersService(data);
            Schools = new DalSchoolsService(data);
            Users = new DalUsersService(data);
        }
    }
}
