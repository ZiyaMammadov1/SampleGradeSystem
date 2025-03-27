using Microsoft.EntityFrameworkCore;
using SampleGradeSystem.Context;

namespace SampleGradeSystem.Helpers
{
    public static class DatabaseInitializer
    {
        public static void MigrateDatabase(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<GradeContext>();
                context.Database.Migrate();
            }
        }
    }
}
