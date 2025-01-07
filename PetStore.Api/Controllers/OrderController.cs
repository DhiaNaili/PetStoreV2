using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetStore.Application.DTOs;
using PetStore.Application.Features.OrderFeatures.Requests.Commands;
using PetStore.Application.Features.OrderFeatures.Requests.Queries;
using PetStore.Application.Features.PetFeatures.Requests.Commands;
using PetStore.Application.Features.PetFeatures.Requests.Queries;
using PetStore.Domain;

namespace PetStore.Api.Controllers
{
    [Route("Store/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult<OrderDto>> Create([FromBody] PlaceOrderCommand command)
        {
            var order = await _mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { id = order.Id }, order);
        }

        [HttpGet("status/{status}")]
        public async Task<ActionResult<List<OrderDto>>> GetByStatus(string status)
        {
            var orders = await _mediator.Send(new GetOrdersByStatusRequest { Status = status });
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> Get(long id)
        {
            var order = await _mediator.Send(new GetOrderByIdRequest { Id = id });
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _mediator.Send(new DeleteOrderCommand { Id = id });
            return NoContent();  
        }




    }
}
