﻿using EasyWallet.Categories.Business.Abstractions;
using EasyWallet.Categories.Data.Abstractions;
using EasyWallet.Categories.Data.Entities;
using EasyWallet.Categories.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyWallet.Categories.Business.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }        

        public async Task<int> CreateCategory(int userId, string name, List<string> keywordsNames)
        {
            var userKeywords = await _unitOfWork.Keywords.GetActiveKeywordsByUser(userId);

            Keyword autogeneratedKeyword;
            var newCategoryKeywords = new List<Keyword>();

            foreach (var keywordName in keywordsNames)
            {
                autogeneratedKeyword = userKeywords.FirstOrDefault(t => t.Name == keywordName && t.IsAutoGenerated);
                if (autogeneratedKeyword != null)
                    autogeneratedKeyword.DeletedAt = DateTime.UtcNow;

                newCategoryKeywords.Add(new Keyword()
                {
                    Name = keywordName,
                    CreatedAt = DateTime.UtcNow
                });
            }

            var category = new Category()
            {
                UserId = userId,
                Name = name,
                Type = CategoryType.Expense,
                CreatedAt = DateTime.UtcNow,
                Keywords = newCategoryKeywords
            };

            await _unitOfWork.Categories.AddAsync(category);
            await _unitOfWork.CommitAsync();

            return category.Id;
        }

        public async Task<List<Category>> GetCategoriesByUser(int userId)
        {
            var categories = await _unitOfWork.Categories.GetActiveCategoriesWithKeywordsByUser(userId);

            foreach (var category in categories)
            {
                category.Keywords = category.Keywords
                    .Where(t => t.DeletedAt == null && !t.IsAutoGenerated)
                    .ToList();
            }

            return new List<Category>(categories);
        }

        public async Task<Category> GetCategory(int id)
        {
            var category = await _unitOfWork.Categories.GetActiveCategoryWithKeywordsById(id);

            if (category != null)
            {
                category.Keywords = category.Keywords
                    .Where(t => t.DeletedAt == null && !t.IsAutoGenerated)
                    .ToList();
            }

            return category;
        }

        public async Task UpdateCategory(int categoryId, string name, List<string> keywords)
        {
            var category = await _unitOfWork.Categories.GetActiveCategoryWithKeywordsById(categoryId);
            category.Name = name;

            var userKeywords = await _unitOfWork.Keywords.GetActiveKeywordsByUser(category.UserId);
            var newKeywords = new List<Keyword>();

            foreach (var keyword in keywords)
            {
                bool keywordExists = userKeywords.Any(k => k.Name == keyword && !k.IsAutoGenerated);

                if (!keywordExists)
                {
                    var autogeneratedKeyword = userKeywords.FirstOrDefault(k => k.Name == keyword && k.IsAutoGenerated);
                    if (autogeneratedKeyword != null)
                        autogeneratedKeyword.DeletedAt = DateTime.UtcNow;

                    newKeywords.Add(new Keyword()
                    {
                        CategoryId = category.Id,
                        Name = keyword,
                        CreatedAt = DateTime.UtcNow
                    });
                }
            }

            await _unitOfWork.Keywords.AddRangeAsync(newKeywords);

            foreach (var categoryKeyword in category.Keywords)
            {
                if (!keywords.Any(k => k == categoryKeyword.Name))
                    categoryKeyword.DeletedAt = DateTime.UtcNow;
            }

            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteCategory(int id)
        {
            var category = await _unitOfWork.Categories.GetActiveCategoryWithKeywordsById(id);
            category.DeletedAt = DateTime.UtcNow;

            foreach (var keyword in category.Keywords)
                keyword.DeletedAt = DateTime.UtcNow;

            await _unitOfWork.CommitAsync();
        }
    }
}
