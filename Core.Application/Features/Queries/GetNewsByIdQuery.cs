using Core.Application.Interfaces.Repositories;
using Core.Domain.Models;

namespace Core.Application.Features.Queries
{
    public class GetNewsByIdQuery : IRequest<News>
    {
        public Guid Id { get; private set; }

        public GetNewsByIdQuery(Guid Id)
        {
            this.Id = Id;
        }
    }

    public class GetNewsByIdHandler : IRequestHandler<GetNewsByIdQuery, News>
    {
        private readonly INewsRepository _newsRepository;
        private readonly IMediator _mediator;

        public GetNewsByIdHandler(IMediator mediator, INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
            _mediator = mediator;
        }

        public async Task<News> Handle(GetNewsByIdQuery request, CancellationToken cancellationToken)
        {
            return await _newsRepository.GetByIdAsync(request.Id);
        }
    }
}
