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
    public class NewsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public NewsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<NewsController>
        [HttpGet("allNews")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<News>> GetAllNews()
        {
            return await _mediator.Send(new GetAllNewsQuery());
        }

        // GET api/<NewsController>/5
        [HttpGet("newsById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<News> GetNewsById(Guid id)
        {
            return await _mediator.Send(new GetNewsByIdQuery(id));
        }

        // POST api/<NewsController>
        [HttpPost("createNews")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Guid>> CreateNews([FromBody] CreateNewsCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        // PUT api/<NewsController>/5
        [HttpPut("editNews/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Guid>> EditNews(Guid id, [FromBody] EditNewsCommand command)
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

        // DELETE api/<NewsController>/5
        [HttpDelete("deleteNews/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> DeleteNews(Guid id)
        {
            try
            {
                string result = string.Empty;
                result = await _mediator.Send(new DeleteNewsCommand(id));
                return Ok(result);
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }
    }
}
