using System.Collections.Generic;

namespace EasyWallet.Categories.Api.Dtos
{
    public class CreateCategoryRequest
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public List<string> KeywordsNames { get; set; }
    }
}
