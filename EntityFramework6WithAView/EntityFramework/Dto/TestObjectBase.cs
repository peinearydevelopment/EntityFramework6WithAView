using System;

namespace EntityFramework6WithAView.EntityFramework.Dto
{
    public class TestObjectBase
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int TestObjectId { get; set; }
        public int UserId { get; set; }
        public DateTimeOffset ActionDateTimeOffset { get; set; }
        public ActionType ActionType { get; set; }
    }
}
