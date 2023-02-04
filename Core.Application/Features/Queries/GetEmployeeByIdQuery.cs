using Core.Application.Interfaces.Repositories;
using Core.Domain.Models;

namespace Core.Application.Features.Queries
{
    public class GetEmployeeByIdQuery : IRequest<Employee>
    {
        public Guid Id { get; private set; }

        public GetEmployeeByIdQuery(Guid Id)
        {
            this.Id = Id;
        }
    }

    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, Employee>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMediator _mediator;

        public GetEmployeeByIdHandler(IMediator mediator, IEmployeeRepository branchRepository)
        {
            _employeeRepository = branchRepository;
            _mediator = mediator;
        }

        public async Task<Employee> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var res = await _employeeRepository.GetByIdAsync(request.Id);
            return res;
        }
    }
}
