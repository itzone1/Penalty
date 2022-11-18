using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Penalty.EntityFrameworkCore
{
    public static class PenaltyDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<PenaltyDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<PenaltyDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
