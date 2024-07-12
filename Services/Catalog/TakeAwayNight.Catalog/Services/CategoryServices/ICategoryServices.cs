using TakeAwayNight.Catalog.Dtos.CategoryDto;

namespace TakeAwayNight.Catalog.Services.CategoryServices
{
    public interface ICategoryServices
    {
        Task<List<ResultCategoryDto>> GettAllCategoryAsync();
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task DeleteCategoryAsync(string id);
        Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id);
    }
}
