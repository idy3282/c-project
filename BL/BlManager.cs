using BL.Api;
using Dal.Api;
using BL.Services;
using Dal;
using Microsoft.Extensions.DependencyInjection;

namespace BL
{
    public class BlManager : IBL
    {
        public IBLUsers Users { get; }

        public IBLExpenditures Expenditures { get; }

        public IBLSchools Schools { get; }

        public IBLSuppliers Suppliers { get; }

        public IBLCategories Categories { get; }


        public BlManager()
        {
            IDal dal = new DalManager();

            /*  Users = new BlUsersService(dal);


              Schools = new BlSchoolsService(dal);

              Suppliers = new BlSuppliersService(dal);

              Categories = new BlCategoriesService(dal);

              Expenditures = new BlExpendituresService(dal);*/


            ServiceCollection services = new ServiceCollection();
            services.AddSingleton<IBLCategories, BlCategoriesService>();
            services.AddSingleton<IBLExpenditures, BlExpendituresService>();
            services.AddSingleton<IBLSchools, BlSchoolsService>();
            services.AddSingleton<IBLUsers, BlUsersService>();
            services.AddSingleton<IBLSuppliers, BlSuppliersService>();
            services.AddSingleton<IDal, DalManager>();
            services.AddSingleton< BlExpenditureForSupplier>();


            ServiceProvider serviceProvider = services.BuildServiceProvider();
            Users = serviceProvider.GetRequiredService<IBLUsers>();
            Schools = serviceProvider.GetRequiredService<IBLSchools>();
            Suppliers = serviceProvider.GetRequiredService<IBLSuppliers>();
            Categories = serviceProvider.GetRequiredService<IBLCategories>();
            Expenditures = serviceProvider.GetRequiredService<IBLExpenditures>();



        }
    }
}