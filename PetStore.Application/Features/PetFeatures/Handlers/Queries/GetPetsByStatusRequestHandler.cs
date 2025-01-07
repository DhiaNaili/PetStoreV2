using AutoMapper;
using MediatR;
using PetStore.Application.Contracts.Persistance;
using PetStore.Application.DTOs;
using PetStore.Application.Features.PetFeatures.Requests.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Application.Features.PetFeatures.Handlers.Queries
{
    public class GetPetsByStatusRequestHandler : IRequestHandler<GetPetsByStatusRequest, List<PetDto>>
    {
        private readonly IPetRepository _petRepository;
        private readonly IMapper _mapper;

        public GetPetsByStatusRequestHandler(IPetRepository petRepository, IMapper mapper)
        {
            _petRepository = petRepository;
            _mapper = mapper;
        }

        public async Task<List<PetDto>> Handle(GetPetsByStatusRequest request, CancellationToken cancellationToken)
        {
            var pets = await _petRepository.GetPetsByStatus(request.status);
            return _mapper.Map<List<PetDto>>(pets);
        }
    }
}
