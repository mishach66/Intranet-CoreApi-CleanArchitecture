using Core.Application.Interfaces.Repositories;
using Core.Application.Mapper;
using Core.Domain.Models;
using Microsoft.AspNetCore.Http;
using FluentValidation;
using Core.Application.DTO;

namespace Core.Application.Features.Commands
{
    public class CreateEmployeeCommand : IRequest<Guid>
    {
        public string? Givenname { get; set; }
        public string? Surname { get; set; }
        public string? IdNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
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
        //public List<Language>? Languages { get; set; }
        public List<Guid>? LanguageСlassifiersIds { get; set; }
        public string? ImageName { get; set; }
        public IFormFile? ImageFile { get; set; }
    }
    
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, Guid>
    {
        private readonly IEmployeeRepository _iEmployeeRepository;
        private readonly IMediator _mediator;

        public CreateEmployeeHandler(IEmployeeRepository iEmployeeRepository, IMediator mediator)
        {
            _iEmployeeRepository = iEmployeeRepository;
            _mediator = mediator;
        }

        public async Task<Guid> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employeeentity = AppMapper.Mapper.Map<Employee>(request);

            FileDTO fileUploadRequest = new();
            fileUploadRequest.File = request.ImageFile;
            var fileUploadResult = await _mediator.Send(new FileUploadCommand { FileForUpoad = fileUploadRequest });
            employeeentity.ImageName = fileUploadResult.UploadedFileUrl;

            if (employeeentity is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }

            await _iEmployeeRepository.InsertAsync(employeeentity);

            foreach (var langId in request.LanguageСlassifiersIds)
            {
                await _mediator.Send(new CreateLanguageCommand { EmployeeId = employeeentity.Id, LanguageСlassifierId = langId });
            }

            return employeeentity.Id;
        }
    }
    
    public class EmployeeValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.Givenname)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!")
                .Matches(@"^[ა-ჰa-zA-Z]{2,20}$").WithMessage("დასაშვებია მხოლოდ ქართული და ლათინური ასოები, 2-დან 20-მდე სიმბოლო")
                //.Length(2, 20).WithMessage("ველი {PropertyName} უნდა შეიცავდეს 2-დან 20-მდე სიმბოლოს") // ეს მუშაობს
                .Must(HasOnlyLetters).WithMessage("{PropertyName} should be all letters.");

            RuleFor(x => x.Surname)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .Matches(@"^[ა-ჰa-zA-Z]*$").WithMessage("დასაშვებია მხოლოდ ქართული და ლათინური ასოები")
                .Length(2, 20).WithMessage("Please specify a correct lastname.");

            RuleFor(x => x.IdNumber)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                //.Matches(@"^[0-9]*$").WithMessage("დასაშვებია მხოლოდ რიცხვები") // ეს მუშაობს
                .Must(x => HasOnlyDigits(x)).WithMessage("ველი {PropertyName} უნდა შეიცავდეს მხოლოდ რიცხვებს")
                .Length(11).WithMessage("{PropertyName} should be not empty and must contaion 11 digits");

            RuleFor(x => x.DateOfBirth.AddYears(18))
                .LessThanOrEqualTo(DateTime.Now).WithMessage("ასაკი დასაშვებზე მცირეა");

            RuleFor(x => x.Email)
                .Cascade(CascadeMode.Stop)
                .Matches(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$").WithMessage("ელ. ფოსტის ფორმატი არასწორია");

            //RuleFor(x => x.Languages).IsInEnum().WithMessage("დაუშვებელი ენა");
        }

        private bool HasOnlyLetters(string name)
        {
            return name.All(Char.IsLetter);
        }

        private bool HasOnlyDigits(string IdentCard)
        {
            return IdentCard.All(Char.IsDigit);
        }
    }
}
