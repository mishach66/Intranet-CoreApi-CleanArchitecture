using Microsoft.AspNetCore.Mvc;
using MediatR;
using Core.Domain.Models;
using Core.Application.Features.Queries;
using Core.Application.Features.Commands;
using Core.Application.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<CityController>
        [HttpGet("allCities")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<City>> GetAllCities()
        {
            return await _mediator.Send(new GetAllCitiesQuery());
        }

        // GET api/<CityController>/5
        [HttpGet("cityById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<City> GetCityById(Guid id)
        {
            return await _mediator.Send(new GetCityByIdQuery(id));
        }

        // POST api/<CityController>
        [HttpPost("createCity")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Guid>> CreateCity([FromBody] CreateCityCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        // PUT api/<CityController>/5
        [HttpPut("editCity/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Guid>> EditCity(Guid id, [FromBody] EditCityCommand command)
        {
            try
            {
                if (command.Id == id)
                {
                    var result = await _mediator.Send(command);
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }

        // DELETE api/<CityController>/5
        [HttpDelete("deleteCity/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> DeleteCity(Guid id)
        {
            try
            {
                string result = string.Empty;
                result = await _mediator.Send(new DeleteCityCommand(id));
                return Ok(result);
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }
    }
}
