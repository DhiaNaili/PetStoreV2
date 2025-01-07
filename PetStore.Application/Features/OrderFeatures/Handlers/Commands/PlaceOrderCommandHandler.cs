using AutoMapper;
using MediatR;
using PetStore.Application.Contracts.Persistence;
using PetStore.Application.DTOs;
using PetStore.Application.Features.OrderFeatures.Requests.Commands;
using PetStore.Domain;


namespace PetStore.Application.Features.OrderFeatures.Handlers.Commands
{
    public class PlaceOrderCommandHandler : IRequestHandler<PlaceOrderCommand, OrderDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        public PlaceOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        public async Task<OrderDto> Handle(PlaceOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _mapper.Map<Order>(request);
            var placeOrder = await _orderRepository.Add(order);
            return _mapper.Map<OrderDto>(placeOrder);
        }
    }
}
