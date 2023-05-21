using Core.Application.Interfaces.Repositories;
using Core.Domain.Models;
using System.Linq;

namespace Core.Application.Features.Queries
{
    public sealed record class GetAllNewsQuery : IRequest<IEnumerable<News>>;
    public class GetAllNewsQueryHandler : IRequestHandler<GetAllNewsQuery, IEnumerable<News>>
    {
        private readonly INewsRepository _newsRepository;
        public GetAllNewsQueryHandler(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public async Task<IEnumerable<News>> Handle(GetAllNewsQuery request, CancellationToken cancellationToken)
        {
            var result = await _newsRepository.GetAllAsync();
            return result.OrderByDescending(n => n.Date).Take(5);
        }
    }
}
