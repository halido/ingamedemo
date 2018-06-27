using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using InGame.BestPractice.Configuration;
using InGame.BestPractice.Web;

namespace InGame.BestPractice.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class BestPracticeDbContextFactory : IDesignTimeDbContextFactory<BestPracticeDbContext>
    {
        public BestPracticeDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<BestPracticeDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            BestPracticeDbContextConfigurer.Configure(builder, configuration.GetConnectionString(BestPracticeConsts.ConnectionStringName));

            return new BestPracticeDbContext(builder.Options);
        }
    }
}
