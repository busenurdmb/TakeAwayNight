using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeAwayNight.Application.Features.CQRS.Commands.AdrressCommands;
using TakeAwayNight.Application.Features.CQRS.Commands.OrderDetailCommands;
using TakeAwayNight.Application.Interfaces;
using TakeAwayNight.Domain.Entities;

namespace TakeAwayNight.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class CreateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public CreateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateOrderDetailCommand command)
        {
            await _repository.CreateAsync(new OrderDetail
            {
               ProductAmount=command.ProductAmount,
               OrderingId=command.OrderingId,
               ProductPrice=command.ProductPrice,
               ProductId=command.ProductId,
               ProductName=command.ProductName,
               ProductTotalPrice=command.ProductTotalPrice
            });
        }
    }
}
