using Microsoft.EntityFrameworkCore;
using SampleGradeSystem.Context;
using SampleGradeSystem.Models.Special;

namespace SampleGradeSystem.Helpers
{
    public static class MockDataSeeder
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                GradeContext context = scope.ServiceProvider.GetRequiredService<GradeContext>();

                if (context is not null && !context.GradeTypes.Any())
                {
                    List<GradeType> gradeTypes = new List<GradeType>()
                    {
                        ObjectFactory.ProduceGradeType("Fixed"),
                        ObjectFactory.ProduceGradeType("Percent"),
                        ObjectFactory.ProduceGradeType("Threshold"),
                    };
                    context.GradeTypes.AddRange(gradeTypes);

                    List<Warehouse> warehouses = new List<Warehouse>()
                    {
                        ObjectFactory.ProduceWareHouse("Prime Storage"),
                        ObjectFactory.ProduceWareHouse("Cargo Central"),
                        ObjectFactory.ProduceWareHouse("Atlas Distribution"),
                    };
                    context.Warehouses.AddRange(warehouses);
                    context.SaveChanges();

                    List<GradeType> types = context.GradeTypes.AsNoTracking().ToList();
                    List<Grade> grades = new List<Grade>()
                    {
                        ObjectFactory.ProduceGrade(name: "FX451", min: 10000, max: null, percent: null, typeId: types.Find(x=>x.Name == "Fixed").Id, 450),
                        ObjectFactory.ProduceGrade(name: "PC738", min: 10000, max: null, percent: 8, typeId: types.Find(x=>x.Name == "Percent").Id, 0),
                        ObjectFactory.ProduceGrade(name: "TH502", min: 10000, max: 20000, percent: 1, typeId: types.Find(x=>x.Name == "Threshold").Id, 0 ),
                        ObjectFactory.ProduceGrade(name: "TH502", min: 20001, max: 30000, percent: (decimal)2.5, typeId: types.Find(x=>x.Name == "Threshold").Id, 0),
                        ObjectFactory.ProduceGrade(name: "TH502", min: 00000, max: 30001, percent: (decimal)3.4, typeId: types.Find(x=>x.Name == "Threshold").Id, 0),
                    };
                    context.Grades.AddRange(grades);
                    context.SaveChanges();

                    List<Store> stores = new List<Store>()
                    {
                        ObjectFactory.ProduceStore(name: "Luxe Fabrics", gradeId: grades.Find(x=>x.Name == "FX451").Id, warehouseId: warehouses.Find(x=>x.Name == "Prime Storage").Id),
                        ObjectFactory.ProduceStore(name: "Loom & Lush", gradeId: grades.Find(x=>x.Name == "PC738").Id, warehouseId: warehouses.Find(x=>x.Name == "Cargo Central").Id),
                        ObjectFactory.ProduceStore(name: "Silk & Style", gradeId: grades.Find(x=>x.Name == "TH502").Id, warehouseId: warehouses.Find(x=>x.Name == "Atlas Distribution").Id),
                        ObjectFactory.ProduceStore(name: "The Stitchery", gradeId: null, warehouseId: warehouses.Find(x=>x.Name == "Atlas Distribution").Id),
                    };
                    context.Stores.AddRange(stores);

                    List<Position> positions = new List<Position>()
                    {
                        ObjectFactory.ProducePosition(name: "Layihə meneceri", salary: 1500, gradeId: grades.Find(x=>x.Name == "FX451").Id),
                        ObjectFactory.ProducePosition(name: "Sistem Administratoru", salary: 2000, gradeId: grades.Find(x=>x.Name == "TH502").Id),
                        ObjectFactory.ProducePosition(name: "Maliyyə müşaviri", salary: 2340, gradeId: grades.Find(x=>x.Name == "TH502").Id),
                        ObjectFactory.ProducePosition(name: "Marketinq meneceri", salary: 1750, gradeId: null),
                        ObjectFactory.ProducePosition(name: "İnsan Resursları Mütəxəssisi", salary: 1550, gradeId: null),
                        ObjectFactory.ProducePosition(name: "Şəbəkə administratoru", salary: 2000, gradeId: grades.Find(x=>x.Name == "PC738").Id),
                        ObjectFactory.ProducePosition(name: "UI/UX Dizayneri", salary: 1600, gradeId: grades.Find(x=>x.Name == "TH502").Id),
                    };
                    context.Positions.AddRange(positions);
                    context.SaveChanges();


                    List<Employee> employees = new List<Employee>()
                    {
                        ObjectFactory.ProduceEmployee(name: "Elvin Məmmədov", positionId: positions.Find(x=>x.Name == "Layihə meneceri").Id, storeId: stores.Find(x=>x.Name == "Luxe Fabrics").Id),
                        ObjectFactory.ProduceEmployee(name: "Aysel Hüseynova", positionId: positions.Find(x=>x.Name == "Sistem Administratoru").Id, storeId: stores.Find(x=>x.Name == "Loom & Lush").Id),
                        ObjectFactory.ProduceEmployee(name: "Nigar Əliyeva", positionId: positions.Find(x=>x.Name == "Maliyyə müşaviri").Id, storeId: stores.Find(x=>x.Name == "Silk & Style").Id),
                        ObjectFactory.ProduceEmployee(name: "Ramin Vəliyev", positionId: positions.Find(x=>x.Name == "Marketinq meneceri").Id, storeId: stores.Find(x=>x.Name == "The Stitchery").Id),
                        ObjectFactory.ProduceEmployee(name: "Leyla İsmayilova", positionId: positions.Find(x=>x.Name == "İnsan Resursları Mütəxəssisi").Id, storeId: stores.Find(x=>x.Name == "Loom & Lush").Id),
                        ObjectFactory.ProduceEmployee(name: "Samir Abbasov", positionId: positions.Find(x=>x.Name == "Şəbəkə administratoru").Id, storeId: stores.Find(x=>x.Name == "Luxe Fabrics").Id),
                        ObjectFactory.ProduceEmployee(name: "Gülnar Məmmədova", positionId: positions.Find(x=>x.Name == "UI/UX Dizayneri").Id, storeId: stores.Find(x=>x.Name == "The Stitchery").Id),
                    };
                    context.Employees.AddRange(employees);
                    context.SaveChanges();
                }

            }
        }
    }
}
