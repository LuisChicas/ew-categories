using EasyWallet.Categories.Data.Entities;
using System.Collections.Generic;

namespace EasyWallet.Categories.Api.Dtos
{
    public class GetCategoriesResponse
    {
        public List<CategoryDto> Categories { get; set; }
    }
}
