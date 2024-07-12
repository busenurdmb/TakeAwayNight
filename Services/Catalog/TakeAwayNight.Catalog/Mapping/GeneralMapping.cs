using AutoMapper;
using TakeAwayNight.Catalog.Dtos.CategoryDto;
using TakeAwayNight.Catalog.Dtos.FeaturesDtos;
using TakeAwayNight.Catalog.Dtos.ProductDtos;
using TakeAwayNight.Catalog.Dtos.SliderDtos;
using TakeAwayNight.Catalog.Entities;

namespace TakeAwayNight.Catalog.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        { 
        CreateMap<Category,CreateCategoryDto>().ReverseMap();
        CreateMap<Category, ResultCategoryDto>().ReverseMap();
        CreateMap<Category, UpdateCategoryDto>().ReverseMap();
        CreateMap<Category, GetByIdCategoryDto>().ReverseMap();

        CreateMap<Product, CreateProductDto>().ReverseMap();
        CreateMap<Product, ResultProductDto>().ReverseMap();
        CreateMap<Product, UpdateProductDto>().ReverseMap();
        CreateMap<Product, GetByIdProductDto>().ReverseMap();

            CreateMap<Features, CreateFeatureDto>().ReverseMap();
            CreateMap<Features, ResultFeatureDto>().ReverseMap(); 
            CreateMap<Features, UpdateFeatureDto>().ReverseMap();
            CreateMap<Features, GetByIdFeatureDto >().ReverseMap();

            CreateMap<Slider, CreateSliderDto>().ReverseMap();
            CreateMap<Slider, ResultSliderDto>().ReverseMap();
            CreateMap<Slider, UpdateSliderDto>().ReverseMap();
            CreateMap<Slider, GetByIdSliderDto>().ReverseMap();
        

        }
    }
}
