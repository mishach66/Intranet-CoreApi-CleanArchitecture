using Core.Application.Interfaces.Repositories;
using Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Features.Queries
{
    public sealed record class GetAllLanguageСlassifiersQuery : IRequest<IEnumerable<LanguageСlassifier>>;

    public class GetAllLanguageСlassifiersQueryHandler : IRequestHandler<GetAllLanguageСlassifiersQuery, IEnumerable<LanguageСlassifier>>
    {
        private readonly ILanguageСlassifiersRepository _languageСlassifiersRepository;
        public GetAllLanguageСlassifiersQueryHandler(ILanguageСlassifiersRepository languageСlassifiersRepository)
        {
            _languageСlassifiersRepository = languageСlassifiersRepository;
        }

        public async Task<IEnumerable<LanguageСlassifier>> Handle(GetAllLanguageСlassifiersQuery request, CancellationToken cancellationToken)
        {
            var res = await _languageСlassifiersRepository.GetAllAsync();
            return res;
        }
    }
}
