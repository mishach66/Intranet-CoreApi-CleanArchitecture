using Core.Application.Interfaces.Repositories;
using Core.Application.Mapper;
using Core.Domain.Models;

namespace Core.Application.Features.Queries
{
    public sealed record class GetAllLanguagesQuery : IRequest<IEnumerable<Language>>;

    public class GetAllLanguagesQueryHandler : IRequestHandler<GetAllLanguagesQuery, IEnumerable<Language>>
    {
        private readonly ILanguageRepository _languageRepository;
        public GetAllLanguagesQueryHandler(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public async Task<IEnumerable<Language>> Handle(GetAllLanguagesQuery request, CancellationToken cancellationToken)
        {
            var res = await _languageRepository.GetAllAsync();
            return res;
        }
    }
}
