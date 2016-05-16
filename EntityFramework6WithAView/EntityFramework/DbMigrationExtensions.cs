using System.Data.Entity.Migrations;
using System.Data.Entity.Migrations.Infrastructure;

namespace EntityFramework6WithAView.EntityFramework
{
    public static class DbMigrationExtensions
    {
        public static void CreateView(this DbMigration migration, string viewName, string viewQueryString)
        {
            ((IDbMigration)migration).AddOperation(new CreateViewMigrationOperation(viewName, viewQueryString));
        }

        public static void DropView(this DbMigration migration, string viewName)
        {
            ((IDbMigration)migration).AddOperation(new DropViewMigrationOperation(viewName));
        }
    }
}
