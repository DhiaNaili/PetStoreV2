using AutoMapper;
using MediatR;
using PetStore.Application.Contracts.Persistence;
using PetStore.Application.DTOs;
using PetStore.Application.Features.OrderFeatures.Requests.Queries;
using PetStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Application.Features.OrderFeatures.Handlers.Queries
{
    public class GetOrderByIdRequestHandler : IRequestHandler<GetOrderByIdRequest, OrderDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        public GetOrderByIdRequestHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<OrderDto> Handle(GetOrderByIdRequest request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrderById(request.Id);
            return _mapper.Map<OrderDto>(order);
        }

    }
}
