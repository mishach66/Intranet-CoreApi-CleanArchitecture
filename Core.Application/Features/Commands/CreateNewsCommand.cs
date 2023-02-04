using Core.Application.Interfaces.Repositories;
using Core.Application.Mapper;
using Core.Domain.Models;
using System.Web.Mvc;

namespace Core.Application.Features.Commands
{
    public class CreateNewsCommand : IRequest<Guid>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        [AllowHtml]
        public string Hyperlink { get; set; }
    }

    public class CreateNewsHandler : IRequestHandler<CreateNewsCommand, Guid>
    {
        private readonly INewsRepository _iNewsRepository;
        private readonly IMediator _mediator;

        public CreateNewsHandler(INewsRepository iNewsRepository, IMediator mediator)
        {
            _iNewsRepository = iNewsRepository;
            _mediator = mediator;
        }

        public async Task<Guid> Handle(CreateNewsCommand request, CancellationToken cancellationToken)
        {
            var newsentity = AppMapper.Mapper.Map<News>(request);

            if (newsentity is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }

            await _iNewsRepository.InsertAsync(newsentity);
            return newsentity.Id;
        }
    }
}
