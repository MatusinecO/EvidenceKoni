using EvidenceKoni.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EvidenceKoni
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();


            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
                {
                    options.Password.RequiredLength = 8;
                    options.Password.RequireNonAlphanumeric = false;
                    options.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
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
                pattern: "{controller=Home}/{action=Index}/{id?}"); //--> zmìnìn routing na Home/Index
                                                                    //pattern: "{controller=Owners}/{action=Index}/{id?}"); // --> jako výchozí bude Owners
                                                                    //Odstranìno kvùli vyžadování vychozích pohledù autentizace (Razor pages)
                                                                    //app.MapRazorPages();



            using (IServiceScope scope = app.Services.CreateScope())
            {
                RoleManager<IdentityRole> roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                UserManager<IdentityUser> userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

                // Seznam emailù, které mají být nastaveny jako správci
                List<string> adminEmails = new List<string>
                {
                    "on.matusinec@gmail.com",
                    "example@example.com"
                };

                foreach (string email in adminEmails)
                {
                    IdentityUser? user = await userManager.FindByEmailAsync(email);

                    if (user == null)
                    {
                        // Pokud uživatel neexistuje, vytvoøím nového uživatele
                        IdentityUser newUser = new IdentityUser { UserName = email, Email = email };
                        await userManager.CreateAsync(newUser);

                        // Pøidám nového uživatele do role admina
                        await userManager.AddToRoleAsync(newUser, UserRoles.Admin);
                    }
                    else
                    {
                        // Pokud uživatel již existuje, zkontroluji, zda je v roli admina
                        if (!await userManager.IsInRoleAsync(user, UserRoles.Admin))
                        {
                            // Pokud není, pøidám ho do této role
                            await userManager.AddToRoleAsync(user, UserRoles.Admin);
                        }
                    }
                }
            }


            app.Run();
        }
    }
}