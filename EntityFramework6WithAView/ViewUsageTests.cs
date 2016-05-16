using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using EntityFramework6WithAView.EntityFramework;
using EntityFramework6WithAView.EntityFramework.Dto;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EntityFramework6WithAView
{
    [TestClass]
    public class ViewUsageTests
    {
        [TestMethod]
        public async Task ValidateViewEffectiveness()
        {
            // ARRANGE
            using (var context = new TestDbContext())
            {
                context.AllTestObjects.Add(new HistoricalTestObject { TestObjectId = 1, ActionType = ActionType.Create, ActionDateTimeOffset = DateTime.UtcNow.AddDays(-5), UserId = 1, Description = "Created HistoricalTestObject, id:1" });
                context.AllTestObjects.Add(new HistoricalTestObject { TestObjectId = 2, ActionType = ActionType.Create, ActionDateTimeOffset = DateTime.UtcNow.AddDays(-3), UserId = 1, Description = "Created HistoricalTestObject, id:2" });
                context.AllTestObjects.Add(new HistoricalTestObject { TestObjectId = 2, ActionType = ActionType.Delete, ActionDateTimeOffset = DateTime.UtcNow, UserId = 1, Description = "Deleted HistoricalTestObject, id:2" });
                await context.SaveChangesAsync();
            }

            // ACT
            using (var context = new TestDbContext())
            {
                var deletedHistoricalTestObject = context.AllTestObjects.FirstOrDefault(historicalTestObject => historicalTestObject.ActionType == ActionType.Delete);
                var createdHistoricalTestObject = context.AllTestObjects.GroupBy(historicalTestObject => historicalTestObject.TestObjectId).FirstOrDefault(group => group.Any(item => item.ActionType != ActionType.Delete)).FirstOrDefault();
                var createdTestObject = context.TestObjects.FirstOrDefault(to => to.Id == createdHistoricalTestObject.Id);
                var deletedTestObject = context.TestObjects.FirstOrDefault(to => to.Id == deletedHistoricalTestObject.Id);

            // ASSERT
                Assert.IsNotNull(createdTestObject);
                Assert.IsNull(deletedTestObject);

            // CLEAN UP
                context.AllTestObjects.RemoveRange(await context.AllTestObjects.ToArrayAsync());
                await context.SaveChangesAsync();
            }
        }
    }
}
