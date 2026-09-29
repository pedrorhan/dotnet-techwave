using Microsoft.AspNetCore.Identity;

namespace dotnet_store.Models;

public static class SeedDatabase
{
    public static async Task InitializeAsync(IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<AppRole>>();

        if (!roleManager.Roles.Any())
        {
            var admin = new AppRole { Name = "Admin" };

            await roleManager.CreateAsync(admin);
        }

        if (!userManager.Users.Any())
        {
            var admin = new AppUser
            {
                AdSoyad = "Orhan Saçlı",
                UserName = "orhanscl",
                Email = "admin@techwave.com",
            };
            var customer = new AppUser
            {
                AdSoyad = "Akın Saçlı",
                UserName = "akinscl",
                Email = "customer@techwave.com",
            };
            await userManager.CreateAsync(admin, "12345678");
            await userManager.AddToRoleAsync(admin, "Admin");
            await userManager.CreateAsync(customer, "12345678");
        }
    }

}