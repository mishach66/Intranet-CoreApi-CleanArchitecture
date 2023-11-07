using Core.Application.Interfaces.Repositories;
using Core.Domain.Models;
using Infrastructure.Persistence.Data;
using Infrastructure.Persistence.Implementation.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Implementation
{
    public class LanguageСlassifiersRepository : RepositoryBase<LanguageСlassifier>, ILanguageСlassifiersRepository
    {
        public LanguageСlassifiersRepository(AppDbContext context) : base(context)
        {
        }
    }
}
