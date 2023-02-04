using Core.Application.Interfaces.Repositories;
using Core.Domain.Models;
using MediatR;

namespace Core.Application.Features.Queries
{
    public sealed record class GetAllEmployeesQuery : IRequest<IEnumerable<Employee>>;
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, IEnumerable<Employee>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        public GetAllEmployeesQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<Employee>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            return await _employeeRepository.GetAllAsync();
        }
    }
}
