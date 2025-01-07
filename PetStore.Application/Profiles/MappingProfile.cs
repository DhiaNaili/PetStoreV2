using AutoMapper;
using PetStore.Application.DTOs;
using PetStore.Application.Features.OrderFeatures.Requests.Commands;
using PetStore.Application.Features.PetFeatures.Requests.Commands;
using PetStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
             CreateMap<Pet, PetDto>().ReverseMap();
             CreateMap<Tag,TagDto>().ReverseMap(); 
             CreateMap<Category,CategoryDto>().ReverseMap();
             CreateMap<Order, OrderDto>().ReverseMap();
             CreateMap<PlaceOrderCommand, Order>().ReverseMap();
             CreateMap<CreatePetCommand, Pet>();
             CreateMap<UpdatePetCommand, Pet>();

        }
    }
    
}
