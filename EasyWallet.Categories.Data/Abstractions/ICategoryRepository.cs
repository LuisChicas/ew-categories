using EasyWallet.Categories.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyWallet.Categories.Data.Abstractions
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<IEnumerable<Category>> GetActiveCategoriesWithKeywordsByUser(int userId);

        Task<Category> GetActiveCategoryWithKeywordsById(int id);
    }
}
