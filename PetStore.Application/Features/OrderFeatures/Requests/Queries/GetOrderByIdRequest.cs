using MediatR;
using PetStore.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Application.Features.OrderFeatures.Requests.Queries
{
    public class GetOrderByIdRequest : IRequest<OrderDto>
    {
        public long Id { get; set; }

    }
}
