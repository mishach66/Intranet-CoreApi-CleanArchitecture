using Core.Application.Interfaces.Repositories;
using Core.Application.Mapper;
using Core.Domain.Models;
using System.Web.Mvc;

namespace Core.Application.Features.Commands
{
    public class CreateVacancyCommand : IRequest<Guid>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime PublicationDate { get; set; }
        [AllowHtml]
        public string JobDescripRequirement { get; set; }
        [AllowHtml]
        public string Hyperlink { get; set; }
        public DateTime Deadline { get; set; }
    }

    public class CreateVacancyHandler : IRequestHandler<CreateVacancyCommand, Guid>
    {
        private readonly IVacancyRepository _iVacancyRepository;
        private readonly IMediator _mediator;

        public CreateVacancyHandler(IVacancyRepository iVacancyRepository, IMediator mediator)
        {
            _iVacancyRepository = iVacancyRepository;
            _mediator = mediator;
        }

        public async Task<Guid> Handle(CreateVacancyCommand request, CancellationToken cancellationToken)
        {
            var vacancyentity = AppMapper.Mapper.Map<Vacancy>(request);

            if (vacancyentity is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }

            await _iVacancyRepository.InsertAsync(vacancyentity);
            return vacancyentity.Id;
        }
    }
}
