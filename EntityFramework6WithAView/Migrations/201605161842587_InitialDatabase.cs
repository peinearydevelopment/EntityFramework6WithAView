using EntityFramework6WithAView.EntityFramework;
using System.Data.Entity.Migrations;

namespace EntityFramework6WithAView.Migrations
{
    public partial class InitialDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HistoricalTestObjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        TestObjectId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        ActionDateTimeOffset = c.DateTimeOffset(nullable: false, precision: 7),
                        ActionType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);

            this.CreateView("dbo.TestObjects",
               @"SELECT 
                    HistoricalTestObjects.Id
                  , HistoricalTestObjects.Description
                  , HistoricalTestObjects.ActionType
                  , HistoricalTestObjects.ActionDateTimeOffset
                  , HistoricalTestObjects.TestObjectId
                  , HistoricalTestObjects.UserId
                 FROM 
                    HistoricalTestObjects
                 INNER JOIN
                    (
                        SELECT MAX(Id) Id
                        FROM HistoricalTestObjects
                        GROUP BY TestObjectId
                    ) T ON T.Id = HistoricalTestObjects.Id
                 WHERE 
                        T.Id IS NOT NULL
                    AND ActionType != 2");
        }
        
        public override void Down()
        {
            DropTable("dbo.TestObjects");
            this.DropView("dbo.TestObjects");
        }
    }
}
