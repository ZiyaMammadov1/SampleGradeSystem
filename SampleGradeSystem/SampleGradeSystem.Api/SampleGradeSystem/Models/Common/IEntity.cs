namespace SampleGradeSystem.Models.Common
{
    public interface IEntity
    {
        public int Id { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ModifyTime { get; set; }
        public bool isDeleted { get; set; }
    }
}
