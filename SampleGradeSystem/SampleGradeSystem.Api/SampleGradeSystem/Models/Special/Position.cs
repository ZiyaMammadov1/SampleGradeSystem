using Microsoft.EntityFrameworkCore;
using SampleGradeSystem.Models.Common;

namespace SampleGradeSystem.Models.Special
{
    public class Position : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ModifyTime { get; set; }
        public bool isDeleted { get; set; }

        [Precision(18,2)]
        public decimal Salary { get; set; }

        public int? GradeId { get; set; }
        public Grade Grade { get; set; }

        public Position SetName(string name)
        {
            Name = name;
            return this;
        }

        public Position SetSalary(decimal salary)
        {
            Salary = salary;
            return this;
        }

        public Position SetGradeId(int? gradeId)
        {
            GradeId = gradeId;
            return this;
        }

    }
}
