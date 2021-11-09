using System.Collections.Generic;

namespace EasyWallet.Categories.Api.Dtos
{
    public class UpdateCategoryRequest
    {
        public string Name { get; set; }
        public List<string> KeywordsNames { get; set; }
    }
}
