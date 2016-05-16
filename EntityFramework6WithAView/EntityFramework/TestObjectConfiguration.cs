using System.Data.Entity.ModelConfiguration;
using EntityFramework6WithAView.EntityFramework.Dto;

namespace EntityFramework6WithAView.EntityFramework
{
    public class TestObjectConfiguration : EntityTypeConfiguration<TestObject>
    {
        public TestObjectConfiguration()
        {
            HasKey(t => t.Id);
            ToTable("dbo.TestObjects");
        }
    }
}
