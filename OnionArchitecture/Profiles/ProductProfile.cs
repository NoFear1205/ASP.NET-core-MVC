using AutoMapper;
using DomainLayer.Model;
using OnionArchitecture.Models.Mapper;

namespace OnionArchitecture.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            //Map dto => Product
            CreateMap<ProductDTO, Product>()
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src.Name }"))
                .ForMember(
                    dest => dest.Provider,
                    opt => opt.MapFrom(src => $"{src.Provider }"))
                .ForMember(
                    dest => dest.CategoryID,
                    opt => opt.MapFrom(src => $"{src.CategoryID }"))
                .ForMember(
                    dest => dest.Image,
                    opt => opt.MapFrom(src => $"{src.Image }"));
            //Map Product => dto
            CreateMap<Product, ProductDTO>()
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src.Name }"))
                .ForMember(
                    dest => dest.Provider,
                    opt => opt.MapFrom(src => $"{src.Provider }"))
                .ForMember(
                    dest => dest.CategoryID,
                    opt => opt.MapFrom(src => $"{src.CategoryID }"))
                .ForMember(
                    dest => dest.Image,
                    opt => opt.MapFrom(src => $"{src.Image }"))
                .ForMember(
                    dest => dest.CategoryName,
                    opt => opt.MapFrom(src => $"{src.Category.CategoryName }"));
        }
    }
}
