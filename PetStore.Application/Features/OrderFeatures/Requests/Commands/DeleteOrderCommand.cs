using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Application.Features.OrderFeatures.Requests.Commands
{
    public class DeleteOrderCommand : IRequest
    {
        public long Id { get; set; }

    }
}
