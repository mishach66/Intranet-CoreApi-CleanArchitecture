using Core.Application.Interfaces.Repositories;

namespace Core.Application.Features.Commands
{
    public class DeleteEmployeeCommand : IRequest<string>
    {
        public Guid Id { get; private set; }
        public DeleteEmployeeCommand(Guid id)
        {
            this.Id = id;
        }
    }

    public class DeleteEmployeehHandler : IRequestHandler<DeleteEmployeeCommand, String>
    {
        private readonly IEmployeeRepository _iEmployeeRepository;
        private readonly IMediator _mediator;

        public DeleteEmployeehHandler(IEmployeeRepository iEmployeeRepository, IMediator mediator)
        {
            _iEmployeeRepository = iEmployeeRepository;
            _mediator = mediator;
        }

        public async Task<string> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _iEmployeeRepository.DeleteAsync(request.Id);
            }
            catch (Exception exp)
            {
                throw (new ApplicationException(exp.Message));
            }

            return "Employee has been deleted!";
        }
    }
}
