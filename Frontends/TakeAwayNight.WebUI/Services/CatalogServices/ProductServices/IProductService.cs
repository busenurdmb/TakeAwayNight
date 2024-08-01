using TakeAwayNight.WebUI.Dtos.CatalogDtos;

namespace TakeAwayNight.WebUI.Services.CatalogServices.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
    }
}
