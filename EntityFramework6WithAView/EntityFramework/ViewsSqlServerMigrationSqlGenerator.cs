using System.Data.Entity.Migrations.Model;
using System.Data.Entity.SqlServer;

namespace EntityFramework6WithAView.EntityFramework
{
    public class ViewsSqlServerMigrationSqlGenerator : SqlServerMigrationSqlGenerator
    {
        protected override void Generate(MigrationOperation migrationOperation)
        {
            var createViewOperation = migrationOperation as CreateViewMigrationOperation;
            if (createViewOperation != null)
            {
                using (var writer = Writer())
                {
                    writer.WriteLine($"CREATE VIEW {createViewOperation.ViewName} AS {createViewOperation.ViewString};");
                    Statement(writer);
                }
            }

            var deleteViewOperation = migrationOperation as DropViewMigrationOperation;
            if (deleteViewOperation != null)
            {
                using (var writer = Writer())
                {
                    writer.WriteLine($"DROP VIEW {deleteViewOperation.ViewName};");
                    Statement(writer);
                }
            }
        }
    }
}
