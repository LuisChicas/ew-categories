using EasyWallet.Categories.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyWallet.Categories.Data.Entities
{
    public class Category : Entity
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "varchar(16)")]
        public CategoryType Type { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public List<Keyword> Keywords { get; set; }
    }
}
