using AutoMapper;
using System;

namespace EasyWallet.Categories.Api.Helpers
{
    internal static class ApiMapper
    {
        public static IMapper Mapper => Lazy.Value;

        public static T Map<T>(object source) => Mapper.Map<T>(source);

        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var configuration = new MapperConfiguration(config =>
            {
                config.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                config.AddProfile<MapperProfile>();
            });

            return configuration.CreateMapper();
        });

        private class MapperProfile : Profile
        {
            public MapperProfile()
            {
                CreateMap<Data.Entities.Category, Dtos.CategoryDto>().ReverseMap();
                CreateMap<Data.Entities.Keyword, Dtos.KeywordDto>().ReverseMap();
            }
        }
    }
}
