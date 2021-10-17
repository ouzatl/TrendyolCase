using Microsoft.EntityFrameworkCore;
using Trendyol.Data.Models;

namespace Trendyol.Data.TrendyolContext
{
    public class TrendyolPostgreSqlContext : DbContext
    {
        public virtual DbSet<DeepLink> DeepLinks { get; set; }
        public TrendyolPostgreSqlContext(DbContextOptions<TrendyolPostgreSqlContext> options) : base(options) { }
    }
}