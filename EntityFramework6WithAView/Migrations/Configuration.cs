using System.Data.Entity.Migrations;
using EntityFramework6WithAView.EntityFramework;

namespace EntityFramework6WithAView.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<TestDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = $"EntityFramework6WithAView.{TestDbContext.ConnectionStringId}";
            SetSqlGenerator("System.Data.SqlClient", new ViewsSqlServerMigrationSqlGenerator());
        }

        protected override void Seed(TestDbContext context)
        {
        }
    }
}
