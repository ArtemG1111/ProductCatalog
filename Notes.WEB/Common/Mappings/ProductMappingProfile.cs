using AutoMapper;
using ProductCatalog.DataAccess.Data.Models;

namespace ProductCatalog.WEB.Common.Mappings
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, Category>().ReverseMap();
        }
    }
}
