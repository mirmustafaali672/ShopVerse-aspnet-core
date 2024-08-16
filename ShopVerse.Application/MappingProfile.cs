using AutoMapper;
using ShopVerse.Demos;
using ShopVerse.Brands;
using ShopVerse.Categories;
using ShopVerse.Products;
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

            CreateMap<Product, ProductCreateOrUpdateDto>();
            CreateMap<ProductCreateOrUpdateDto, Product>();
            CreateMap<Product, ProductGetDto>();
            CreateMap<ProductGetDto, Product>();
            CreateMap<Product, ProductGetListDto>();
            CreateMap<ProductGetListDto, Product>();

            CreateMap<ProductImage, CreateOrUpdateProductImage>();
            CreateMap<CreateOrUpdateProductImage, ProductImage>();
            CreateMap<ProductImage, ProductGetImage>();
            CreateMap<ProductGetImage, ProductImage>();
            
        }
    }
}
