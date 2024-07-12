using TakeAwayNight.Catalog.Dtos.SliderDtos;



namespace TakeAwayNight.Catalog.Services.SliderServices
{
    public interface ISliderServices
    {
        Task<List<ResultSliderDto>> GettAllSliderAsync();
        Task CreateSliderAsync(CreateSliderDto createSliderDto);
        Task UpdateSliderAsync(UpdateSliderDto updateSliderDto);
        Task DeleteSliderAsync(string id);
        Task<GetByIdSliderDto> GetByIdSliderAsync(string id);
    }
}
