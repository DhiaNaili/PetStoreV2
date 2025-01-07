using MediatR;
using PetStore.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Application.Features.PetFeatures.Requests.Queries
{
    public class GetPetByIdRequest : IRequest<PetDto>
    {
        public long Id { get; set; }
    }
}
