using EasyWallet.Categories.Api.Dtos;

namespace EasyWallet.Categories.Api.Abstractions
{
    public interface IErrorService
    {
        Error DuplicatedCategoryNameError { get; }
        Error DuplicatedKeywordNameError { get; }
    }
}
