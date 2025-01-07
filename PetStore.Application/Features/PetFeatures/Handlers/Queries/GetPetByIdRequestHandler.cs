using AutoMapper;
using MediatR;
using PetStore.Application.Contracts.Persistance;
using PetStore.Application.DTOs;
using PetStore.Application.Features.PetFeatures.Requests.Queries;
using PetStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Application.Features.PetFeatures.Handlers.Queries
{
    public class GetPetByIdRequestHandler : IRequestHandler<GetPetByIdRequest, PetDto>
    {
        private readonly IPetRepository _petRepository;
        private readonly IMapper _mapper;

        public GetPetByIdRequestHandler(IPetRepository petRepository, IMapper mapper)
        {
            _petRepository = petRepository;
            _mapper = mapper;
        }

        public async Task<PetDto> Handle(GetPetByIdRequest request, CancellationToken cancellationToken)
        {
            var pet =await _petRepository.Get(request.Id);
            return _mapper.Map<PetDto>(pet);
        }
    }
}
