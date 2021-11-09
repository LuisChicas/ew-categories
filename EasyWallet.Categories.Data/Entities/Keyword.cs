﻿using System;
using System.ComponentModel.DataAnnotations;

namespace EasyWallet.Categories.Data.Entities
{
    public class Keyword : Entity
    {
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsAutoGenerated { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public Category Category { get; set; }
    }
}
