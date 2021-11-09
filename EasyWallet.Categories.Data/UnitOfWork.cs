using EasyWallet.Categories.Data.Repositories;
using EasyWallet.Categories.Data.Abstractions;
using System.Threading.Tasks;

namespace EasyWallet.Categories.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoryRepository Categories => _categoryRepository = _categoryRepository ?? new CategoryRepository(_context);
        public IKeywordRepository Keywords => _keywordRepository = _keywordRepository ?? new KeywordRepository(_context);

        private readonly CategoriesContext _context;
        private CategoryRepository _categoryRepository;
        private KeywordRepository _keywordRepository;

        public UnitOfWork(CategoriesContext context)
        {
            _context = context;
        }

        public Task<int> CommitAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
