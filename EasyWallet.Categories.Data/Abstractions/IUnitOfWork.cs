using System;
using System.Threading.Tasks;

namespace EasyWallet.Categories.Data.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Categories { get; }
        IKeywordRepository Keywords { get; }


        Task<int> CommitAsync();
    }
}
