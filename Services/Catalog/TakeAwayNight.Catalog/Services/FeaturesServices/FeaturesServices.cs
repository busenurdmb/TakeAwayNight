using AutoMapper;
using MongoDB.Driver;
using TakeAwayNight.Catalog.Dtos.FeaturesDtos;
using TakeAwayNight.Catalog.Entities;
using TakeAwayNight.Catalog.Settings;

namespace TakeAwayNight.Catalog.Services.FeaturesServices
{
    public class FeaturesServices : IFeaturesServices
    {
        private readonly IMongoCollection<Features> _FeatureCollection;
        private readonly IMapper _mapper;

        public FeaturesServices(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _FeatureCollection = database.GetCollection<Features>(_databaseSettings.FeatureCollectionName);
            _mapper = mapper;
        }

        public async Task CreateFeatureAsync(CreateFeatureDto createFeatureDto)
        {
            var value = _mapper.Map<Features>(createFeatureDto);
            await _FeatureCollection.InsertOneAsync(value);
        }

        public async Task DeleteFeatureAsync(string id)
        {
            await _FeatureCollection.DeleteOneAsync(x => x.FeaturesId == id);
        }

        public async Task<GetByIdFeatureDto> GetByIdFeatureAsync(string id)
        {
            var values = await _FeatureCollection.Find<Features>(x => x.FeaturesId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdFeatureDto>(values);
        }

        public async Task<List<ResultFeatureDto>> GettAllFeatureAsync()
        {
            var values = await _FeatureCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultFeatureDto>>(values);
        }

        public async Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto)
        {
            var values = _mapper.Map<Features>(updateFeatureDto);
            await _FeatureCollection.FindOneAndReplaceAsync(x => x.FeaturesId == updateFeatureDto.FeaturesId, values);
        }
    }
}
