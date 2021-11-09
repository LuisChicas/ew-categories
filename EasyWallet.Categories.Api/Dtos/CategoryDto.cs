using EasyWallet.Categories.Data.Enums;
using System;
using System.Collections.Generic;

namespace EasyWallet.Categories.Api.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CategoryType Type { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<KeywordDto> Keywords { get; set; }
    }
}
