using AutoMapper;
using MongoDB.Driver;
using TakeAwayNight.Catalog.Dtos.SliderDtos;
using TakeAwayNight.Catalog.Entities;
using TakeAwayNight.Catalog.Settings;

namespace TakeAwayNight.Catalog.Services.SliderServices
{
    public class SliderServices : ISliderServices
    {
        private readonly IMongoCollection<Slider> _SliderCollection;
        private readonly IMapper _mapper;

        public SliderServices(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _SliderCollection = database.GetCollection<Slider>(_databaseSettings.SliderCollectionName);
            _mapper = mapper;
        }

        public async Task CreateSliderAsync(CreateSliderDto createSliderDto)
        {
            var value = _mapper.Map<Slider>(createSliderDto);
            await _SliderCollection.InsertOneAsync(value);
        }

        public async Task DeleteSliderAsync(string id)
        {
            await _SliderCollection.DeleteOneAsync(x => x.SliderId == id);
        }

        public async Task<GetByIdSliderDto> GetByIdSliderAsync(string id)
        {
            var values = await _SliderCollection.Find<Slider>(x => x.SliderId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdSliderDto>(values);
        }

        public async Task<List<ResultSliderDto>> GettAllSliderAsync()
        {
            var values = await _SliderCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultSliderDto>>(values);
        }

        public async Task UpdateSliderAsync(UpdateSliderDto updateSliderDto)
        {
            var values = _mapper.Map<Slider>(updateSliderDto);
            await _SliderCollection.FindOneAndReplaceAsync(x => x.SliderId == updateSliderDto.SliderId, values);
        }
    }
}
