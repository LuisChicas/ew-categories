using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyWallet.Categories.Data.Abstractions
{
    public interface IRepository<TEntity> where TEntity : class
    {
        ValueTask<TEntity> GetByIdAsync(int id);
        Task<int> AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
    }
}
