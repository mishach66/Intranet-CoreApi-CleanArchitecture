using Microsoft.AspNetCore.Mvc;
using MediatR;
using Core.Domain.Models;
using Core.Application.Features.Queries;
using Core.Application.Features.Commands;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<EmployeeController>
        [HttpGet("allEmployees")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await _mediator.Send(new GetAllEmployeesQuery());
        }

        // GET api/<EmployeeController>/5
        [HttpGet("employeeById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Employee> GetEmployeeById(Guid id)
        {
            return await _mediator.Send(new GetEmployeeByIdQuery(id));
        }

        // GET api/<EmployeeController>/5
        [HttpGet("employeeByIdWithBranch/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Employee> GetEmployeeByIdWithBranch(Guid id)
        {
            return await _mediator.Send(new GetEmployeeByIdWithBranchQuery(id));
        }
        
        // POST api/<EmployeeController>
        [HttpPost("createEmployee")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Guid>> CreateEmployee([FromForm] CreateEmployeeCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("editEmployee/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Guid>> EditEmployee(Guid id, [FromForm] EditEmployeeCommand command)
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

        // DELETE api/<EmployeeController>/5
        [HttpDelete("deleteEmployee/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> DeleteEmployee(Guid id)
        {
            try
            {
                string result = string.Empty;
                result = await _mediator.Send(new DeleteEmployeeCommand(id));
                return Ok(result);
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }
    }
}
