using AutoMapper;
using AutoMapperSample.Dtos;
using AutoMapperSample.Entities;

namespace AutoMapperSample.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile() 
        {
            CreateMap<Product, ProductDto>()
                .ForMember(
                    dest => dest.CreatedDate,
                    opt => opt.MapFrom(
                        src => src.CreatedAt.ToString("yyyy-MM-dd"))
                );
            CreateMap<CreateProductDto, Product>();
        }
    }
}
