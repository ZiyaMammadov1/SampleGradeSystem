using Microsoft.EntityFrameworkCore;
using SampleGradeSystem.Context;
using SampleGradeSystem.Data.Repositories.Implementations;
using SampleGradeSystem.Data.Repositories.Interfaces;
using SampleGradeSystem.Data.UnitOfWork.Implementations;
using SampleGradeSystem.Data.UnitOfWork.Interfaces;
using SampleGradeSystem.Helpers;
using SampleGradeSystem.Models.Special;
using SampleGradeSystem.Pipeline;

namespace SampleGradeSystem;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<GradeContext>();
        builder.Services.AddHealthChecks();
        builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
        builder.Services.AddApplicationServices();

        var app = builder.Build();
        app.MapHealthChecks("/health");

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            DatabaseInitializer.MigrateDatabase(app.Services);
            MockDataSeeder.Seed(app.Services);
        }

        app.UseMiddleware<GlobalExceptionMiddleware>();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}
