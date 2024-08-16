using AutoMapper;
using ShopVerse.Demos;
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
        }
    }
}
