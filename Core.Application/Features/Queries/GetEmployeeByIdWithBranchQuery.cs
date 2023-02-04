using Core.Application.Interfaces.Repositories;
using Core.Domain.Models;

namespace Core.Application.Features.Queries
{
    public class GetEmployeeByIdWithBranchQuery : IRequest<Employee>
    {
        public Guid Id { get; private set; }

        public GetEmployeeByIdWithBranchQuery(Guid Id)
        {
            this.Id = Id;
        }
    }

    public class GetEmployeeByIdWithBranchHandler : IRequestHandler<GetEmployeeByIdWithBranchQuery, Employee>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMediator _mediator;

        public GetEmployeeByIdWithBranchHandler(IMediator mediator, IEmployeeRepository branchRepository)
        {
            _employeeRepository = branchRepository;
            _mediator = mediator;
        }

        public async Task<Employee> Handle(GetEmployeeByIdWithBranchQuery request, CancellationToken cancellationToken)
        {
            var res = await _employeeRepository.GetByIdWithBranchAsync(request.Id);
            return res;
        }
    }
}
