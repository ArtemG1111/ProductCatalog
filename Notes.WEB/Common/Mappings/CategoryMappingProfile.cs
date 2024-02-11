using AutoMapper;
using ProductCatalog.DataAccess.Data.Models;
using ProductCatalog.WEB.ViewModels;

namespace ProductCatalog.WEB.Common.Mappings
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<Category, CategoryViewModel>().ReverseMap();
        }
    }
}
