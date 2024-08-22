using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using TakeAwaySignalR.WebApi.DAL;

namespace TakeAwaySignalR.WebApi.Hubs
{
    //
    public class SignalRHub:Hub
    {
        private readonly Context _context;

        public SignalRHub(Context context)
        {
            _context = context;
        }
       
        public async Task TotalDeliveryCount()
        {
            var value1 =  _context.Deliveries.Count();
            await Clients.All.SendAsync("ReceiveToatalDelieveryCouunt", value1);
            var value4 = _context.Deliveries.Where(x => x.Status == "Teslim Edildi").Count();
            await Clients.All.SendAsync("ReceiveTotalDeliveryCountStatusByTeslimEdildi", value4);

        }
        public async Task TotalDeliveryCountStatusYolda()
        {
            var value2 = _context.Deliveries.Where(x => x.Status == "Yolda").Count();
            await Clients.All.SendAsync("ReceiveTotalDeliveryCountStatusYolda", value2);

        }
        public async Task TotalDeliveryCountStatusHazirlaniyor()
        {
            var value3 = _context.Deliveries.Where(x => x.Status == "Hazirlaniyor").Count();

            await Clients.All.SendAsync("ReceiveTotalDeliveryCountStatusHazirlaniyor", value3);

        }
        public async Task GetDeliveryList()
        {
            var value = _context.Deliveries.ToList();
            await Clients.All.SendAsync("ReceiveDeliveryList", value);
        }
    }
}
