using EasyWallet.Categories.Data.Abstractions;
using EasyWallet.Categories.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyWallet.Categories.Data.Repositories
{
    public class KeywordRepository : Repository<Keyword>, IKeywordRepository
    {
        private CategoriesContext _context => Context as CategoriesContext;

        public KeywordRepository(CategoriesContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Keyword>> GetActiveKeywordsByUser(int userId)
        {
            return await _context.Categories
                .Where(c => c.UserId == userId && c.DeletedAt == null)
                .SelectMany(c => c.Keywords)
                .Where(t => t.DeletedAt == null)
                .ToListAsync();
        }
    }
}
