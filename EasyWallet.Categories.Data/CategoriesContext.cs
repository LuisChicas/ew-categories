using EasyWallet.Categories.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasyWallet.Categories.Data
{
    public class CategoriesContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Keyword> Keywords { get; set; }

        public CategoriesContext(DbContextOptions<CategoriesContext> options) : base(options) { }
    }
}

/*
 
 migrationBuilder.Sql(string.Format(
                @"
                    ALTER TABLE Categories 
                    MODIFY COLUMN Type ENUM({0});

                ", GetCategoryTypeValues()));


        private string GetCategoryTypeValues()
        {
            var values = Enum.GetValues(typeof(CategoryType))
                .OfType<string>()
                .Select(i => $"'{i}'");

            return string.Join(',', values);
        }
 
 */