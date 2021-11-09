using EasyWallet.Categories.Data.Abstractions;
using EasyWallet.Categories.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyWallet.Categories.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private CategoriesContext CategoriesContext => Context as CategoriesContext;

        public CategoryRepository(CategoriesContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Category>> GetActiveCategoriesWithKeywordsByUser(int userId)
        {
            return await CategoriesContext.Categories
                .Where(c => c.UserId == userId && c.DeletedAt == null)
                .Include(c => c.Keywords)
                .OrderByDescending(c => c.CreatedAt)
                .ToListAsync();
        }

        public Task<Category> GetActiveCategoryWithKeywordsById(int id)
        {
            return CategoriesContext.Categories
                .Where(c => c.Id == id && c.DeletedAt == null)
                .Include(c => c.Keywords)
                .FirstOrDefaultAsync();
        }
    }
}
