using AutoMapper;
using ProductReview.Application.Dtos.ProductDtos;
using ProductReview.Domain;

namespace ProductReview.Application.Mappings;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, GetProductDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.RowKey))
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.PartitionKey));

        CreateMap<CreateProductDto, Product>()
            .ForMember(dest => dest.RowKey, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.PartitionKey, opt => opt.MapFrom(src => src.Category));
    }
}
