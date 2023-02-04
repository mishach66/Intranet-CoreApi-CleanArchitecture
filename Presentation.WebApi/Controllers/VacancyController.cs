using Core.Application.Features.Commands;
using Core.Application.Features.Queries;
using Core.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacancyController : ControllerBase
    {
        private readonly IMediator _mediator;
        public VacancyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<VacancyController>
        [HttpGet("allVacancies")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<Vacancy>> GetAllVacancies()
        {
            return await _mediator.Send(new GetAllVacanciesQuery());
        }

        // GET api/<VacancyController>/5
        [HttpGet("vacancyById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Vacancy> GetVacancyById(Guid id)
        {
            return await _mediator.Send(new GetVacancyByIdQuery(id));
        }

        // POST api/<VacancyController>
        [HttpPost("createVacancy")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Guid>> CreateVacancy([FromBody] CreateVacancyCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        // PUT api/<VacancyController>/5
        [HttpPut("editVacancy/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Guid>> EditVacancy(Guid id, [FromBody] EditVacancyCommand command)
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

        // DELETE api/<VacancyController>/5
        [HttpDelete("deleteVacancy/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> DeleteVacancy(Guid id)
        {
            try
            {
                string result = string.Empty;
                result = await _mediator.Send(new DeleteVacancyCommand(id));
                return Ok(result);
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }
    }
}
