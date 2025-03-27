using Microsoft.EntityFrameworkCore;
using SampleGradeSystem.Models.Common;
using System.Diagnostics;

namespace SampleGradeSystem.Models.Special
{
    public class Store : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ModifyTime { get; set; }
        public bool isDeleted { get; set; }

        public int? GradeId { get; set; }
        public Grade Grade { get; set; }

        public int WareHouseId { get; set; }
        public Warehouse Warehouse { get; set; }

        public Store SetName(string name)
        {
            Name = name;
            return this;
        }
        public Store SetGradeId(int? gradeId)
        {
            GradeId = gradeId;
            return this;
        }
        public Store SetWareHouseId(int warehouseId)
        {
            WareHouseId = warehouseId;
            return this;
        }
    }
}
