using Core.Application.DTO;
using Core.Application.Features.Commands;
using Core.Application.Features.Queries;
using Core.Application.Pagination;
using Core.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BranchController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //// GET: api/<BranchController>
        //[HttpGet("allBranches")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<IEnumerable<Branch>> GetAllBranches([FromQuery] PaginationFilter? filter)
        //{
        //    return await _mediator.Send(new GetAllBranchesQuery(filter));
        //}

        // GET: api/<BranchController>
        [HttpGet("allBranches")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<BranchesWithTotalCount> GetAllBranches([FromQuery] PaginationFilter? filter)
        {
            var res = await _mediator.Send(new GetAllBranchesQuery(filter));
            return res;
        }

        // GET: api/<BranchController>
        [HttpGet("allBranchesWithoutPagination")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<BranchesWithTotalCount> GetAllBranches()
        {
            var res = await _mediator.Send(new GetAllBranchesQuery());
            return res;
        }

        // GET api/<BranchController>/5
        [HttpGet("branchById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Branch> GetBranchById(Guid id)
        {
            return await _mediator.Send(new GetBranchByIdQuery(id));
        }

        // POST api/<BranchController>
        [HttpPost("createBranch")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Guid>> CreateBranch([FromBody] CreateBranchCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        // PUT api/<BranchController>/5
        [HttpPut("editBranch/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Guid>> EditBranch(Guid id, [FromBody] EditBranchCommand command)
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

        // DELETE api/<BranchController>/5
        [HttpDelete("deleteBranch/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> DeleteBranch(Guid id)
        {
            try
            {
                string result = string.Empty;
                result = await _mediator.Send(new DeleteBranchCommand(id));
                return Ok(result);
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }
    }
}
