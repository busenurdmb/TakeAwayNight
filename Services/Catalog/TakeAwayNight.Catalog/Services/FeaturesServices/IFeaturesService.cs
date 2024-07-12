
using TakeAwayNight.Catalog.Dtos.FeaturesDtos;

namespace TakeAwayNight.Catalog.Services.FeaturesServices
{
    public interface IFeaturesServices
    {
        Task<List<ResultFeatureDto>> GettAllFeatureAsync();
        Task CreateFeatureAsync(CreateFeatureDto createFeatureDto);
        Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto);
        Task DeleteFeatureAsync(string id);
        Task<GetByIdFeatureDto> GetByIdFeatureAsync(string id);
    }
}
