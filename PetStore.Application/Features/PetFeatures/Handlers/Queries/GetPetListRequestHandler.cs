using AutoMapper;
using MediatR;
using PetStore.Application.DTOs;
using PetStore.Application.Features.PetFeatures.Requests.Queries;
using PetStore.Application.Contracts.Persistance;


namespace PetStore.Application.Features.PetFeatures.Handlers.Queries
{
    public class GetPetListRequestHandler : IRequestHandler<GetPetListRequest, List<PetDto>>
    {
        private readonly IPetRepository _petRepository;
        private readonly IMapper _mapper;


        public GetPetListRequestHandler(IPetRepository petRepository,IMapper mapper )
        {
           _petRepository = petRepository;
            _mapper = mapper;
        }


        public async Task<List<PetDto>> Handle(GetPetListRequest request, CancellationToken cancellationToken)
        {
            var Pets = await _petRepository.GetAll();
            return _mapper.Map<List<PetDto>>(Pets);
        }
    }
}
