using TakeAwayNight.Catalog.Dtos.ProductDtos;


namespace TakeAwayNight.Catalog.Services.ProductServices
{
    public interface IProductServices
    {
        Task<List<ResultProductDto>> GettAllProductAsync();
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task DeleteProductAsync(string id);
        Task<GetByIdProductDto> GetByIdProductAsync(string id);
    }
}
