using MediatR;
using Microsoft.AspNetCore.Http;
using PetStore.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Application.Features.PetFeatures.Requests.Commands
{
     public class UploadPetImageCommand : IRequest<PetDto>
    {
        public long PetId { get; set; }
        public IFormFile File { get; set; }
    }
}
