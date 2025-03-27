using Microsoft.EntityFrameworkCore;
using SampleGradeSystem.Models.Common;
using System.Reflection;

namespace SampleGradeSystem.Models.Special
{
    public class Grade : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ModifyTime { get; set; }
        public bool isDeleted { get; set; }

        public int? GradeTypeId { get; set; }
        public GradeType GradeType { get; set; }

        [Precision(7, 2)]
        public decimal? Max { get; set; }

        [Precision(7, 2)]
        public decimal? Min { get; set; }

        [Precision(5, 2)]
        public decimal? Percent { get; set; } 
        
        [Precision(5, 2)]
        public decimal FixGradeAmount { get; set; }

        public Grade SetName(string name)
        {
            Name = name;
            return this;
        }

        public Grade SetMax(decimal? value)
        {
            Max = value;
            return this;
        }
        public Grade SetMin(decimal? value)
        {
            Min = value;
            return this;
        }
        public Grade SetPercent(decimal? value)
        {
            Percent = value;
            return this;
        }
        public Grade SetTypeId(int value)
        {
            GradeTypeId = value;
            return this;
        }

        public Grade SetFixAmount(decimal value)
        {
            FixGradeAmount = value;
            return this;
        }

    }
}
