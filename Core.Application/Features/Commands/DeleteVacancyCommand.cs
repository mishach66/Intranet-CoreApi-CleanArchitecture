using Core.Application.Interfaces.Repositories;

namespace Core.Application.Features.Commands
{
    public class DeleteVacancyCommand : IRequest<string>
    {
        public Guid Id { get; private set; }
        public DeleteVacancyCommand(Guid id)
        {
            this.Id = id;
        }
    }

    public class DeleteVacancyHandler : IRequestHandler<DeleteVacancyCommand, string>
    {
        private readonly IVacancyRepository _iVacancyRepository;
        private readonly IMediator _mediator;

        public DeleteVacancyHandler(IVacancyRepository iVacancyRepository, IMediator mediator)
        {
            _iVacancyRepository = iVacancyRepository;
            _mediator = mediator;
        }

        public async Task<string> Handle(DeleteVacancyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _iVacancyRepository.DeleteAsync(request.Id);
            }
            catch (Exception exp)
            {
                throw (new ApplicationException(exp.Message));
            }

            return "Vacancy has been deleted!";
        }
    }
}
