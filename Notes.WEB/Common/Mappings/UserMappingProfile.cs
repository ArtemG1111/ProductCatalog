using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ProductCatalog.WEB.ViewModels;

namespace ProductCatalog.WEB.Common.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<IdentityUser, UserViewModel>().ReverseMap();
        }
    }
}
