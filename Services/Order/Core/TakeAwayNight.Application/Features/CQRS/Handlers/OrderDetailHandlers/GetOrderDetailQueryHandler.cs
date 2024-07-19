using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeAwayNight.Application.Features.CQRS.Results.AddressResults;
using TakeAwayNight.Application.Features.CQRS.Results.OrderDetailResults;
using TakeAwayNight.Application.Interfaces;
using TakeAwayNight.Domain.Entities;

namespace TakeAwayNight.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetOrderDetailQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetOrderDetailQueryResult
            {
                ProductAmount = x.ProductAmount,
                ProductTotalPrice = x.ProductTotalPrice,
                ProductName = x.ProductName,
                ProductId = x.ProductId,
                ProductPrice = x.ProductPrice,
                OrderingId = x.OrderingId,
                OrderDetailId = x.OrderDetailId,
            }).ToList();
        }
    }
}
