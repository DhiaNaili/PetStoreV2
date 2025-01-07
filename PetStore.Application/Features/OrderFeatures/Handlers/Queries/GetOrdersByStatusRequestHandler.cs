using AutoMapper;
using MediatR;
using PetStore.Application.Contracts.Persistence;
using PetStore.Application.DTOs;
using PetStore.Application.Features.OrderFeatures.Requests.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Application.Features.OrderFeatures.Handlers.Queries
{
    public class GetOrdersByStatusRequestHandler : IRequestHandler<GetOrdersByStatusRequest, List<OrderDto>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        public GetOrdersByStatusRequestHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        public async Task<List<OrderDto>> Handle(GetOrdersByStatusRequest request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetOrdersByStatus(request.Status);
            return _mapper.Map<List<OrderDto>>(orders);
        }
    }
}
