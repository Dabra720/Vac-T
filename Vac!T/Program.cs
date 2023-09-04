using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Vac_T.Contexts;
using Vac_T.Models;
using Vac_T.Areas.Identity.Data;

namespace Vac_T
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<VacItContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("VacItContext")));

            builder.Services.AddDefaultIdentity<Vac_TUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<VacItContext>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=JobOffers}/{action=Index}/{id?}");
            app.MapRazorPages();

            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                var roles = new[] { "Admin", "ROLE_EMPLOYER", "ROLE_CANDIDATE" };

                foreach(var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                        await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            using (var scope = app.Services.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<Vac_TUser>>();

                string email = "admin@admin.com";
                string password = "Test12#";

                if(await userManager.FindByEmailAsync(email) == null)
                {
                    var user = new Vac_TUser();
                    user.UserName = email;
                    user.Email = email;
                    user.EmailConfirmed = true;
                    await userManager.CreateAsync(user, password);

                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }

            app.Run();
        }
    }
}