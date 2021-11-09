using EasyWallet.Categories.Api.Dtos;
using EasyWallet.Categories.Api.Helpers;
using EasyWallet.Categories.Business.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyWallet.Categories.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<Response<CreateCategoryResponse>> Create([FromBody] CreateCategoryRequest request)
        {
            int categoryId = await _categoryService.CreateCategory(request.UserId, request.Name, request.KeywordsNames);

            return new Response<CreateCategoryResponse>
            {
                Data = new CreateCategoryResponse
                {
                    CategoryId = categoryId
                }
            };
        }

        [HttpGet]
        public async Task<Response<GetCategoriesResponse>> GetCategories([FromQuery] int userId)
        {
            var categories = await _categoryService.GetCategoriesByUser(userId);

            GetCategoriesResponse data = null;

            if (categories.Any())
            {
                var categoriesDtos = ApiMapper.Map<List<CategoryDto>>(categories);

                data = new GetCategoriesResponse
                {
                    Categories = categoriesDtos
                };
            }

            return new Response<GetCategoriesResponse> { Data = data };
        }

        [HttpGet("{id}")]
        public async Task<Response<object>> GetCategory(int id)
        {
            var category = await _categoryService.GetCategory(id);

            var categoryDto = ApiMapper.Map<CategoryDto>(category);

            return new Response<object> 
            { 
                Data = category == null ? null : new 
                {
                    category = categoryDto
                }
            };
        }

        [HttpPut("{id}")]
        public async Task<Response> Update(int id, [FromBody] UpdateCategoryRequest request)
        {
            await _categoryService.UpdateCategory(id, request.Name, request.KeywordsNames);

            return new Response { Message = "Category updated." };
        }

        [HttpDelete("{id}")]
        public async Task<Response> Delete(int id)
        {
            await _categoryService.DeleteCategory(id);

            return new Response { Message = "Category deleted." };
        }
    }
}
