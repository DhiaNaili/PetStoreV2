using MediatR;
using PetStore.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Application.Features.PetFeatures.Requests.Queries
{
    public class GetPetListRequest : IRequest<List<PetDto>>
    {

    }
}
