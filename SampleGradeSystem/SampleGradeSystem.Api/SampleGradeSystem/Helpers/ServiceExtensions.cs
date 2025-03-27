using Microsoft.EntityFrameworkCore;
using SampleGradeSystem.Context;
using SampleGradeSystem.Data.Repositories.Implementations;
using SampleGradeSystem.Data.Repositories.Interfaces;
using SampleGradeSystem.Data.UnitOfWork.Implementations;
using SampleGradeSystem.Data.UnitOfWork.Interfaces;
using SampleGradeSystem.Models.Special;
using SampleGradeSystem.Services;

namespace SampleGradeSystem.Helpers
{
    public static class ServiceExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<DbContext, GradeContext>();

            services.AddScoped<IRepository<Employee>, EmployeeRepository>();
            services.AddScoped<IRepository<Grade>, GradeRepository>();
            services.AddScoped<IRepository<GradeType>, GradeTypeRepository>();
            services.AddScoped<IRepository<Position>, PositionRepository>();
            services.AddScoped<IRepository<Store>, StoreRepository>();
            services.AddScoped<IRepository<Warehouse>, WarehouseRepository>();

            services.AddScoped<EmployeeService>();
            services.AddScoped<GradeService>();
            services.AddScoped<GradeTypeService>();
            services.AddScoped<PositionService>();
            services.AddScoped<StoreService>();
            services.AddScoped<WarehouseService>();
            services.AddScoped<SalaryService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
