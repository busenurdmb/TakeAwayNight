using Dapper;
using TakeAwayNight.Discount.Context;
using TakeAwayNight.Discount.Dtos;

namespace TakeAwayNight.Discount.Services
{
    public class DiscountCouponServices : IDiscountCouponServices
    {
        private readonly DapperContext _discountDapperContext;

        public DiscountCouponServices(DapperContext discountDapperContext)
        {
            _discountDapperContext = discountDapperContext;
        }

        public async Task CreateDiscountCouponAsync(CreateDiscountCouponDto createCouponDto)
        {
            string query = "insert into DiscountCoupons (Code,Rate,IsActive) values (@code,@rate,@isActive)";
            var parameters = new DynamicParameters();
            parameters.Add("@code", createCouponDto.Code);
            parameters.Add("@rate", createCouponDto.Rate);
            parameters.Add("@isActive", createCouponDto.IsActive);
           using (var connection = _discountDapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteDiscountCouponAsync(int id)
        {
            string query = "Delete From DiscountCoupons where DiscountCouponId=@DiscountCouponId";
            var parameters = new DynamicParameters();
            parameters.Add("DiscountCouponId", id);
            using (var connection = _discountDapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
        public async Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync()
        {
            string query = "Select * From DiscountCoupons";
            using (var connection = _discountDapperContext.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultDiscountCouponDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int id)
        {
            string query = "Select * From DiscountCoupons Where DiscountCouponId=@DiscountCouponId";
            var parameters = new DynamicParameters();
            parameters.Add("@DiscountCouponId", id);
            using (var connection = _discountDapperContext.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdDiscountCouponDto>(query, parameters);
                return values;
            }
        }
        public async Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateCouponDto)
        {
            string query = "Update DiscountCoupons Set Code=@code,Rate=@rate,IsActive=@isActive where DiscountCouponId=@DiscountCouponId";
            var parameters = new DynamicParameters();
            parameters.Add("@code", updateCouponDto.Code);
            parameters.Add("@rate", updateCouponDto.Rate);
            parameters.Add("@isActive", updateCouponDto.IsActive);
            parameters.Add("@DiscountCouponId", updateCouponDto.DiscountCouponId);
            using (var connection = _discountDapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
