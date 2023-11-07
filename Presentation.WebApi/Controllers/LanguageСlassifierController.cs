using Core.Application.Features.Queries;
using Core.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageСlassifierController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LanguageСlassifierController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<LanguageСlassifierController>
        [HttpGet("allLanguageСlassifiers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<LanguageСlassifier>> GetAllLanguageСlassifiers()
        {
            var res = await _mediator.Send(new GetAllLanguageСlassifiersQuery());
            return res;
        }

        // GET api/<LanguageСlassifierController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LanguageСlassifierController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LanguageСlassifierController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LanguageСlassifierController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
