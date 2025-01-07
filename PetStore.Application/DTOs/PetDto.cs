using PetStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Application.DTOs
{
    public class PetDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public CategoryDto Categories { get; set; }
        public string Status { get; set; }
        public List<string> PhotoUrls { get; set; }
        public List<TagDto> Tags { get; set; }
    }
}
