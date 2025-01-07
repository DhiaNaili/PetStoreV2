using MediatR;
using Microsoft.AspNetCore.Http;
using PetStore.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Application.Features.OrderFeatures.Requests.Queries
{
    public class GetOrdersByStatusRequest : IRequest<List<OrderDto>>
    {
        public string Status { get; set; }
    }
}
