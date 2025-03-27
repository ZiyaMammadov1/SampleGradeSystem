using SampleGradeSystem.Models.Special;

namespace SampleGradeSystem.Helpers
{
    public static class ObjectFactory
    {
        public static GradeType ProduceGradeType(string name)
        {
            return new GradeType().SetName(name);
        }

        public static Warehouse ProduceWareHouse(string name)
        {
            return new Warehouse().SetName(name);
        }

        public static Grade ProduceGrade(string name, decimal? min, decimal? max, decimal? percent, int typeId, decimal fixAmount = 0)
        {
            return new Grade().SetName(name).SetMax(max).SetMin(min).SetPercent(percent).SetTypeId(typeId).SetFixAmount(fixAmount);
        }

        public static Store ProduceStore(string name, int? gradeId, int warehouseId)
        {
            return new Store().SetName(name).SetGradeId(gradeId).SetWareHouseId(warehouseId);
        }

        public static Position ProducePosition(string name, decimal salary, int? gradeId)
        {
            return new Position().SetName(name).SetSalary(salary).SetGradeId(gradeId);
        }

        public static Employee ProduceEmployee(string name, int positionId, int storeId)
        {
            return new Employee().SetName(name).SetPositionId(positionId).SetStoreId(storeId);
        }


    }
}
