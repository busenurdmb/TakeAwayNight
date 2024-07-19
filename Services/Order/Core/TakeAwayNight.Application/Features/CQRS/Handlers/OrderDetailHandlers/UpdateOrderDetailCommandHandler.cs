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
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateOrderDetailCommand command)
        {
            var values = await _repository.GetByIdAsync(command.OrderDetailId);
            values.ProductName = command.ProductName;
            values.ProductId = command.ProductId;
            values.ProductPrice = command.ProductPrice;
            values.ProductTotalPrice=command.ProductTotalPrice;
            values.ProductAmount=command.ProductAmount;
            values.OrderingId=command.OrderingId;
            await _repository.UpdateAsync(values);
        }
    }
}
