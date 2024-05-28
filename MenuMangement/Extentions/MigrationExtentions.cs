using MenuMangement.API.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace MenuMangement.Api.Extentions
{
    public static class MigrationExtentions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();
            using MenuContext dbContext = scope.ServiceProvider.GetRequiredService<MenuContext>();
            dbContext.Database.Migrate();

            // Test

        }
    }
}

