using Microsoft.EntityFrameworkCore;
using Trendyol.Data.Models;
using Trendyol.Data.TrendyolContext;

namespace Trendyol.Data.Repository.DeepLinkRepository
{
    public class DeepLinkRepository : BaseRepository<DeepLink>, IDeepLinkRepository
    {

        private readonly DbContext _dbContext;

        public DeepLinkRepository(TrendyolPostgreSqlContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}