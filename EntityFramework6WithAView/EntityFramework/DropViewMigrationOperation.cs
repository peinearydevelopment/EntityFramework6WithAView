using System.Data.Entity.Migrations.Model;

namespace EntityFramework6WithAView.EntityFramework
{
    public class DropViewMigrationOperation : MigrationOperation
    {
        public DropViewMigrationOperation(string viewName) : base(null)
        {
            ViewName = viewName;
        }

        public string ViewName { get; private set; }

        public override bool IsDestructiveChange => true;
    }
}
