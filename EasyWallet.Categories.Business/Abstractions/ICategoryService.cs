using EasyWallet.Categories.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyWallet.Categories.Business.Abstractions
{
    public interface ICategoryService
    {
        Task<int> CreateCategory(int userId, string name, List<string> keywordsNames);
        Task<List<Category>> GetCategoriesByUser(int userId);
        Task<Category> GetCategory(int id);
        Task UpdateCategory(int categoryId, string name, List<string> keywords);
        Task DeleteCategory(int id);
    }
}
