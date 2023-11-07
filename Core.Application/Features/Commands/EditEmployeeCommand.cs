using Core.Application.Interfaces.Repositories;
using Core.Application.Mapper;
using Core.Domain.Models;

namespace Core.Application.Features.Commands
{
    public class EditEmployeeCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string? Givenname { get; set; }
        public string? Surname { get; set; }
        public string? IdNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Department { get; set; }
        public string? Position { get; set; }
        public string? Email { get; set; }
        public string? MobilePhone { get; set; }
        public string? WorkPhone { get; set; }
        public string? Address { get; set; }
        public string? AdditionalInfo { get; set; }
        public Guid? BranchId { get; set; }
        public Guid? CityId { get; set; }
        //public Languages? Language { get; set; }
        public List<Guid>? Languages { get; set; }
    }

    public class EditEmployeeHandler : IRequestHandler<EditEmployeeCommand, Guid>
    {
        private readonly IEmployeeRepository _iEmployeeRepository;
        private readonly IMediator _mediator;

        public EditEmployeeHandler(IEmployeeRepository iEmployeeRepository, IMediator mediator)
        {
            _iEmployeeRepository = iEmployeeRepository;
            _mediator = mediator;
        }

        public async Task<Guid> Handle(EditEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employeeentity = AppMapper.Mapper.Map<Employee>(request);

            if (employeeentity is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }

            try
            {
                await _iEmployeeRepository.UpdateAsync(employeeentity);
            }
            catch (Exception exp)
            {
                throw new ApplicationException(exp.Message);
            }
            return employeeentity.Id;
        }
    }
}
