using AutoMapper;
using ProductReview.Application.Dtos.ProductDtos;
using ProductReview.Application.Dtos.ReviewDtos;
using ProductReview.Domain;

namespace ProductReview.Application.Mappings;

public class ReviewProfile : Profile
{
    public ReviewProfile()
    {
        CreateMap<Review, GetReviewDto>()
            .ForMember(dest => dest.ReviewId, opt => opt.MapFrom(src => src.RowKey));
        CreateMap<CreateReviewDto, Review>();
    }
}