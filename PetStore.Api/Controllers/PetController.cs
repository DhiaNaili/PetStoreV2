using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetStore.Application.DTOs;
using PetStore.Application.Features.PetFeatures.Requests.Commands;
using PetStore.Application.Features.PetFeatures.Requests.Queries;

namespace PetStore.Api.Controllers
{
     [Route("[controller]")]
     [ApiController]
    public class PetController : Controller
    {
        private readonly IMediator _mediator;
        public PetController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult<PetDto>> Create([FromBody] CreatePetCommand command)
        {
            var pet = await _mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { id = pet.Id }, pet);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            await _mediator.Send(new DeletePetCommand { Id = id });
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<PetDto>>> GetAll()
        {
            var pets = await _mediator.Send(new GetPetListRequest());
            return Ok(pets);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<PetDto>> Update(long id, [FromBody] UpdatePetCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("Mismatched Pet ID in URL and body");
            }

            var updatedPet = await _mediator.Send(command);

            if (updatedPet == null)
            {
                return NotFound($"Pet with ID {id} not found");
            }

            return Ok(updatedPet);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PetDto>> Get(long id)
        {
            var pet = await _mediator.Send(new GetPetByIdRequest { Id = id });
            if (pet == null)
            {
                return NotFound();
            }
            return Ok(pet);
        }

        [HttpGet("status/{status}")]
        public async Task<ActionResult<List<PetDto>>> GetByStatus(string status)
        {
            var pets = await _mediator.Send(new GetPetsByStatusRequest { status = status });
            return Ok(pets);
        }

        [HttpPost("{id}/uploadImage")]
        public async Task<ActionResult<PetDto>> UploadImage(long id, [FromForm] IFormFile file)
        {
            var command = new UploadPetImageCommand
            {
                PetId = id,
                File = file
            };

            var petDto = await _mediator.Send(command);
            if (petDto == null)
            {
                return BadRequest("Invalid pet ID or file");
            }

            return Ok(petDto);
        }
    }
}
