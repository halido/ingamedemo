using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace InGame.BestPractice.EntityFrameworkCore
{
    public static class BestPracticeDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<BestPracticeDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<BestPracticeDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
