using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Application.Features.PetFeatures.Requests.Commands
{
    public class DeletePetCommand : IRequest
    {
        public long Id { get; set; }

    }
}
