using EasyWallet.Categories.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyWallet.Categories.Data.Abstractions
{
    public interface IKeywordRepository : IRepository<Keyword>
    {
        Task<IEnumerable<Keyword>> GetActiveKeywordsByUser(int userId);
    }
}
