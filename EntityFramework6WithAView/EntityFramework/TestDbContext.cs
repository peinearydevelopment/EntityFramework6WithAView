using System.Data.Entity;
using EntityFramework6WithAView.EntityFramework.Dto;

namespace EntityFramework6WithAView.EntityFramework
{
    public class TestDbContext : DbContext
    {
        internal const string ConnectionStringId = "TestDbContext";
        public TestDbContext() : base(ConnectionStringId)
        {
        }

        public DbSet<HistoricalTestObject> AllTestObjects { get; set; }
        public DbSet<TestObject> TestObjects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TestObjectConfiguration());
        }
    }
}
