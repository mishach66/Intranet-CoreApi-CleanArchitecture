using Core.Application.Interfaces.Repositories;
using Core.Application.Pagination;
using Core.Domain.Models;
using MediatR;

namespace Core.Application.Features.Queries
{
    // public sealed record class GetAllEmployeesQuery : IRequest<IEnumerable<Employee>>;
    public sealed record class GetAllEmployeesQuery : IRequest<IEnumerable<Employee>>
    {
        internal PaginationFilter _filter;
        public GetAllEmployeesQuery()
        {

        }
        public GetAllEmployeesQuery(PaginationFilter filter)
        {
            _filter = filter;
        }
    }
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, IEnumerable<Employee>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        public GetAllEmployeesQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<Employee>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            // return await _employeeRepository.GetAllAsync(); // პაგინაციის გარეშე

            // var allEmployees = await _employeeRepository.GetAllAsync(); // თანამშრომლები ფილიალიების გარეშე
            var allEmployees = await _employeeRepository.GetAllWithBranchAsync();
            var allEmployeesList = allEmployees.ToList();
            var validFilter = new PaginationFilter(request._filter.PageNumber, request._filter.PageSize);
            var PgResponse = new PagedResponseGeneric<Employee>(allEmployeesList, validFilter.PageNumber, validFilter.PageSize).PagedList();
            return PgResponse;
        }
    }
}
