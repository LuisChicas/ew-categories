using EasyWallet.Categories.Api.Abstractions;
using EasyWallet.Categories.Api.Dtos;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace EasyWallet.Categories.Api.Services
{
    public class ErrorService : IErrorService
    {
        private readonly string ApiErrorsSectionName = "ApiErrors";

        private readonly IConfiguration Configuration;

        private readonly List<Error> Errors;

        public Error DuplicatedCategoryNameError => Errors.FirstOrDefault(e => e.Name == "DuplicatedCategoryName");
        public Error DuplicatedKeywordNameError => Errors.FirstOrDefault(e => e.Name == "DuplicatedKeywordName");

        public ErrorService(IConfiguration configuration)
        {
            Configuration = configuration;

            Errors = Configuration.GetSection(ApiErrorsSectionName).Get<List<Error>>();
        }
    }
}
