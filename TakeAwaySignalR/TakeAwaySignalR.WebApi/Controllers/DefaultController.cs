using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TakeAwaySignalR.WebApi.DAL;

namespace TakeAwaySignalR.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        private readonly Context _context;

        public DefaultController(Context context)
        {
            _context = context;
        }

        [HttpGet("ToatalDelieveryCouunt")]
        public IActionResult TotalDeliveryCount()
        {
            var values = _context.Deliveries.Count();
            return Ok(values);
        }

        [HttpGet("ToatalDelieveryCouuntStatusYolda")]
        public IActionResult TotalDeliveryCountStatusYolda()
        {
            var values = _context.Deliveries.Where(x=>x.Status=="Yolda").Count();
                
            return Ok(values);
        }
        [HttpGet("ToatalDelieveryCouuntStatusHazirlaniyor")]
        public IActionResult TotalDeliveryCountStatusHazirlaniyor()
        {
            var values = _context.Deliveries.Where(x => x.Status == "Hazirlaniyor").Count();

            return Ok(values);
        }
    }
}
