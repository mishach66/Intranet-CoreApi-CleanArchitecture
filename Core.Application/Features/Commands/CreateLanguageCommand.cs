using Core.Application.Interfaces.Repositories;
using Core.Application.Mapper;
using Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Features.Commands
{
    public class CreateLanguageCommand : IRequest<Guid>
    {
        public Guid? EmployeeId { get; set; }
        public Guid? LanguageСlassifierId { get; set; }
    }

    public class CreateLanguageHandler : IRequestHandler<CreateLanguageCommand, Guid>
    {
        private readonly ILanguageRepository _iLanguageRepository;
        private readonly IMediator _mediator;

        public CreateLanguageHandler(ILanguageRepository iLanguageRepository, IMediator mediator)
        {
            _iLanguageRepository = iLanguageRepository;
            _mediator = mediator;
        }
        public async Task<Guid> Handle(CreateLanguageCommand request, CancellationToken cancellationToken)
        {
            var languageentity = AppMapper.Mapper.Map<Language>(request);

            if (languageentity is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }

            await _iLanguageRepository.InsertAsync(languageentity);
            return languageentity.Id;
        }
    }
}
