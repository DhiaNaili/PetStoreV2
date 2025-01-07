using AutoMapper;
using MediatR;
using PetStore.Application.Contracts.Persistance;
using PetStore.Application.Features.PetFeatures.Requests.Commands;
using PetStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Application.Features.PetFeatures.Handlers.Commands
{
    public class UpdatePetCommandHandler : IRequestHandler<UpdatePetCommand>
    {
        private readonly IPetRepository _petRepository;
        private readonly IMapper _mapper;

        public UpdatePetCommandHandler(IPetRepository petRepository, IMapper mapper)
        {
            _petRepository = petRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdatePetCommand request, CancellationToken cancellationToken)
        {
            var pet = _mapper.Map<Pet>(request);
            await _petRepository.Update(pet);
            return Unit.Value;
        }
    }
}
