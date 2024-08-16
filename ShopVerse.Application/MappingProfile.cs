using AutoMapper;
using ShopVerse.Demos;
using ShopVerse.Brands;
using ShopVerse.Categories;
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

            CreateMap<Category, CategoryCreateOrUpdateDto>();
            CreateMap<CategoryCreateOrUpdateDto, Category>();
            CreateMap<Category, CategoryGetDto>();
            CreateMap<CategoryGetDto, Category>();
            CreateMap<Category, CategoryGetListDto>();
            CreateMap<CategoryGetListDto, Category>();
        }
    }
}
