using SampleGradeSystem.Models.Common;

namespace SampleGradeSystem.Models.Special
{
    public class Employee : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ModifyTime { get; set; }
        public bool isDeleted { get; set; }

        public int PositionId { get; set; }
        public Position Position { get; set; }

        public int StoreId { get; set; }
        public Store Store { get; set; }

        public Employee SetName(string name)
        {
            Name = name;
            return this;
        }

        public Employee SetPositionId(int value)
        {
            PositionId = value;
            return this;
        }

        public Employee SetStoreId(int value)
        {
            StoreId = value;
            return this;
        }
    }
}
