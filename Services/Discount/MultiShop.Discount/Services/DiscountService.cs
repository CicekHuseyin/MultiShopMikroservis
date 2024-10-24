using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _contex;

        public DiscountService(DapperContext contex)
        {
            _contex = contex;
        }

        public async Task CreateDiscountCouponAsync(CreateDiscountCouponDto createDiscountCouponDto)
        {
            string query = "insert into Coupons (Code,Rate,IsActive,ValidDate) values (@code,@rate,@isActive,@validDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@code", createDiscountCouponDto.Code);
            parameters.Add("@rate", createDiscountCouponDto.Rate);
            parameters.Add("@isActive", createDiscountCouponDto.IsActive);
            parameters.Add("@validDate", createDiscountCouponDto.ValidDate);
            using (var connection = _contex.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteDiscountCouponAsync(int id)
        {
            string query = "delete from Coupons where CouponId=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = _contex.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<GetByIdDiscountCouponDto> GetDiscountCouponByIdAsync(int id)
        {
            string query = "select * from Coupons where CouponId=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = _contex.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdDiscountCouponDto>(query,parameters);
                return values;
            }
        }

        public async Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync()
        {
            string query = "select * from Coupons";
            using (var connection = _contex.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultDiscountCouponDto>(query);
                return values.ToList();
            }
        }

        public async Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateDiscountCouponDto)
        {
            string query = "update Coupons set Code=@code,Rate=@rate,IsActive=@isActive,ValidDate=@validDate where CouponId=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@code", updateDiscountCouponDto.Code);
            parameters.Add("@rate", updateDiscountCouponDto.Rate);
            parameters.Add("@isActive", updateDiscountCouponDto.IsActive);
            parameters.Add("@validDate", updateDiscountCouponDto.ValidDate);
            parameters.Add("@id", updateDiscountCouponDto.CouponId);
            using (var connection = _contex.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
