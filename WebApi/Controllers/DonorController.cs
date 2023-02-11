using Application.Features.Commands.CreateDonorCommand;
using Application.Features.Commands.DeleteDonorCommand;
using Application.Features.Commands.UpdateDonorCommand;
using Application.Features.Queries.GetDonorQuery;
using Application.Features.Queries.GetDonorsQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorController : ControllerBase
    {
        private IMediator _mediator;

        public DonorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDonor([FromBody]CreateDonorRequestModel request)
        {
            var result = await _mediator.Send(new CreateDonorRequestModel { FirstName = request.FirstName, LastName = request.LastName, Password = request.Password, Email = request.Email});
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDonor()
        {
            return Ok(await _mediator.Send(new GetDonorsRequestModel()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDonorById(int id)
        {
            return Ok(await _mediator.Send(new GetDonorRequestModel { Id = id }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDonor(int id)
        {
            return Ok(await _mediator.Send(new DeleteDonorRequestModel { Id = id }));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDonor(int id, UpdateDonorRequestModel request)
        {
            if(id != request.Id)
            {
                return BadRequest();
            }
            return Ok(await _mediator.Send(request));
        }
    }
}
