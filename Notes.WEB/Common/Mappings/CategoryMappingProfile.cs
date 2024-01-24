using AutoMapper;
using ProductCatalog.DataAccess.Data.Models;

namespace ProductCatalog.WEB.Common.Mappings
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<Product, Category>().ReverseMap();
        }
    }
}
