using MediatR;
using PetStore.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Application.Features.PetFeatures.Requests.Commands
{
    public class UpdatePetCommand : IRequest
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long CategoriesId { get; set; }
        public string Status { get; set; }
        public List<string> PhotoUrls { get; set; }
        public List<TagDto> Tags { get; set; }
    }
}
