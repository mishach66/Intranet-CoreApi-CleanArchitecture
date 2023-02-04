using Core.Application.Interfaces.Repositories;
using Core.Domain.Models;
using Infrastructure.Persistence.Data;
using Infrastructure.Persistence.Implementation.Basic;

namespace Infrastructure.Persistence.Implementation
{
    public class NewsRepository : RepositoryBase<News>, INewsRepository
    {
        public NewsRepository(AppDbContext context) : base(context)
        {
        }
    }
}
