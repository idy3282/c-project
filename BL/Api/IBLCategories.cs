//using Dal.Models;
using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;
namespace BL.Api
{
    public interface IBLCategories
    {
        Task<List<Category>> GetCategories();
        Task<Category> GetCategoryById(int id);
        Task<Category> GetCategoryByName(string name);
        decimal GetDebtSum(string cName);
        decimal GetSumEpendituresOfCategory(string name);
        Category UpdateCategory(Category category, int id);
        Task<bool> Create(Category category);
        void RemoveCategory(int id);
    }
}
