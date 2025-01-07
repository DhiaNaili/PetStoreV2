using MediatR;
using PetStore.Application.Contracts.Persistence;
using PetStore.Application.Features.OrderFeatures.Requests.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Application.Features.OrderFeatures.Handlers.Commands
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public DeleteOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.Get(request.Id);
            if (order == null)
            {
                throw new KeyNotFoundException($"Order with ID {request.Id} not found.");
            }

            await _orderRepository.Delete(order);
            return Unit.Value;  
        }
    }
}

