using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TakeAwayNight.Discount.Dtos;
using TakeAwayNight.Discount.Services;

namespace TakeAwayNight.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountCouponServices _discountCouponServices;

        public DiscountController(IDiscountCouponServices discountCouponServices)
        {
            _discountCouponServices = discountCouponServices;
        }

        [HttpGet]
        public async Task<IActionResult> DiscountCouponList()
        {
            var values = await _discountCouponServices.GetAllDiscountCouponAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiscountCouponById(int id)
        {
            var values = await _discountCouponServices.GetByIdDiscountCouponAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscountCoupon(CreateDiscountCouponDto createCouponDto)
        {
            await _discountCouponServices.CreateDiscountCouponAsync(createCouponDto);
            return Ok("Kupon başarıyla oluşturuldu");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDiscountCoupon(int id)
        {
            await _discountCouponServices.DeleteDiscountCouponAsync(id);
            return Ok("Kupon başarıyla silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDiscountCoupon(UpdateDiscountCouponDto updateCouponDto)
        {
            await _discountCouponServices.UpdateDiscountCouponAsync(updateCouponDto);
            return Ok("İndirim kuponu başarıyla güncellendi");
        }
    }
}
