using AutoMapper;
using MediatR;
using PetStore.Application.Contracts.Persistance;
using PetStore.Application.DTOs;
using PetStore.Application.Features.PetFeatures.Requests.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Application.Features.PetFeatures.Handlers.Commands
{
    public class UploadPetImageCommandHandler : IRequestHandler<UploadPetImageCommand, PetDto>
    {
        private readonly IPetRepository _petRepository;
        private readonly IMapper _mapper;

        public UploadPetImageCommandHandler(IPetRepository petRepository, IMapper mapper)
        {
            _petRepository = petRepository;
            _mapper = mapper;
        }

        public async Task<PetDto> Handle(UploadPetImageCommand request, CancellationToken cancellationToken)
        {
            var pet = await _petRepository.Get(request.PetId);
            if (pet == null)
            {
                return null;
            }

            if (request.File == null || request.File.Length == 0)
            {
                return null;
            }

            var uploadsFolder = Path.Combine("C:\\Uploads", "PetImages");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var filePath = Path.Combine(uploadsFolder, $"{Guid.NewGuid()}_{request.File.FileName}");
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await request.File.CopyToAsync(stream);
            }


            pet.PhotoUrls.Add(filePath);
            await _petRepository.Update(pet);

            return _mapper.Map<PetDto>(pet);
        }
    }
}

