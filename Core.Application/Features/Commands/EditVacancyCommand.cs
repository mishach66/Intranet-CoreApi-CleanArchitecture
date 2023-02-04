using Core.Application.Interfaces.Repositories;
using Core.Application.Mapper;
using Core.Domain.Models;
using System.Web.Mvc;

namespace Core.Application.Features.Commands
{
    public class EditVacancyCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime PublicationDate { get; set; }
        [AllowHtml]
        public string JobDescripRequirement { get; set; }
        [AllowHtml]
        public string Hyperlink { get; set; }
        public DateTime Deadline { get; set; }
    }

    public class EditVacancyHandler : IRequestHandler<EditVacancyCommand, Guid>
    {
        private readonly IVacancyRepository _iVacancyRepository;
        private readonly IMediator _mediator;

        public EditVacancyHandler(IVacancyRepository iVacancyRepository, IMediator mediator)
        {
            _iVacancyRepository = iVacancyRepository;
            _mediator = mediator;
        }

        public async Task<Guid> Handle(EditVacancyCommand request, CancellationToken cancellationToken)
        {
            var vacancyentity = AppMapper.Mapper.Map<Vacancy>(request);

            if (vacancyentity is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }

            try
            {
                await _iVacancyRepository.UpdateAsync(vacancyentity);
            }
            catch (Exception exp)
            {
                throw new ApplicationException(exp.Message);
            }
            return vacancyentity.Id;
        }
    }
}
