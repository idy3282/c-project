using Dal.Api;
using Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Common.Models;
namespace Dal.Services
{
    public class DalCategoriesService : IDalCategories
    {
        dbcontext data;

        public DalCategoriesService(dbcontext data)
        {
            this.data = data;
        }

        public async Task<List<Category>> GetCategories()
        {
            return data.Categories.Include(c => c.Expenditures).ToList();
        }

        public  Category UpdateCategory(Category category, int id)
        {
            return  GetCategories().Result.ToList().Find(c => c.CategoryId == id);
            //GetCategories()[index] = category;
            //data.SaveChanges();
            //return GetCategories()[index];
        }
        public async Task<bool> Create(Category category)
        {
            try
            {
                data.Categories.Add(category);
                try
                {
                    data.SaveChangesAsync();
                }
                catch
                {
                    data.Categories.Local.Remove(category);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("category didn't create");
            }
        }
        public void RemoveCategory(int id)
        {
            try
            {
                var c = GetCategories().Result.ToList().Find(c => c.CategoryId == id);
                data.Categories.Remove(c);
                data.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("category didnt removed");

            }

        }



    }
}
