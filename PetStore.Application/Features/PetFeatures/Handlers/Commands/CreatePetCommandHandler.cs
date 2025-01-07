using AutoMapper;
using MediatR;
using PetStore.Application.Contracts.Persistance;
using PetStore.Application.DTOs;
using PetStore.Application.Features.PetFeatures.Requests.Commands;
using PetStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Application.Features.PetFeatures.Handlers.Commands
{
    public class CreatePetCommandHandler : IRequestHandler<CreatePetCommand, PetDto>
    {
        private readonly IPetRepository _petRepository;
        private readonly IMapper _mapper;

        public CreatePetCommandHandler(IPetRepository petRepository, IMapper mapper)
        {
            _petRepository = petRepository;
            _mapper = mapper;
        }
        public async Task<PetDto> Handle(CreatePetCommand request, CancellationToken cancellationToken)
        {
            var pet = _mapper.Map<Pet>(request);
            pet = await _petRepository.Add(pet);
            return _mapper.Map<PetDto>(pet);
        }
    }
}
