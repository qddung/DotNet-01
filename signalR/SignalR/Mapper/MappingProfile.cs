namespace SignalR.Mapper;

using AutoMapper;
using SignalR.ViewModels;
using SignalR.ViewModels.Category;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ProductVM, ProductDTO>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Alias, opt => opt.MapFrom(src => src.Alias))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Image));

        CreateMap<CategoryViewItem, CategoryOption>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.category));

    }
}
