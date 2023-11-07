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
    public class LanguageController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LanguageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<LanguageController>
        [HttpGet("allLanguages")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<Language>> GetAllLanguages()
        {
            var res = await _mediator.Send(new GetAllLanguagesQuery());
            return res;
        }
    }
}
