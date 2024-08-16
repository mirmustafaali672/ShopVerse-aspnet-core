using AutoMapper;
using ShopVerse.Demos;
using ShopVerse.Brands;
namespace MyApp.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Demo, DemoCreateOrUpdateDto>();
            CreateMap<DemoCreateOrUpdateDto, Demo>();
            CreateMap<Demo, DemoGetDto>();
            CreateMap<DemoGetDto, Demo>();

            CreateMap<Brand, BrandCreateOrUpdateDto>();
            CreateMap<BrandCreateOrUpdateDto, Brand>();
            CreateMap<Brand, BrandGetDto>();
            CreateMap<BrandGetDto, Brand>();
            CreateMap<Brand, BrandGetListDto>();
            CreateMap<BrandGetListDto, Brand>();
        }
    }
}
