using MediatR;
using PetStore.Application.Contracts.Persistance;
using PetStore.Application.Features.PetFeatures.Requests.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Application.Features.PetFeatures.Handlers.Commands
{
    public class DeletePetCommandHandler : IRequestHandler<DeletePetCommand>
    {
        private readonly IPetRepository _petRepository;

        public DeletePetCommandHandler(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public async Task<Unit> Handle(DeletePetCommand request, CancellationToken cancellationToken)
        {
            var pet = await _petRepository.Get(request.Id);
            await _petRepository.Delete(pet);
            return Unit.Value;
        }
    }
}
