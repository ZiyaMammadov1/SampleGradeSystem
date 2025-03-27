using SampleGradeSystem.Models.Common;

namespace SampleGradeSystem.Models.Special
{
    public class GradeType : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ModifyTime { get; set; }
        public bool isDeleted { get; set; }

        public GradeType SetName(string name)
        {
            Name = name;
            return this;
        }
    }
}
