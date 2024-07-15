using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using HospitalManagementProject.Data;
using HospitalManagementProject.Models;
using HospitalManagementProject.Repositories.Contracts;
using HospitalManagementProject.Repositories.Services;
using HospitalManagementProject.WorkerServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Quartz;
using Quartz.Spi;

var builder = WebApplication.CreateBuilder(args);
// Console.WriteLine(Guid.NewGuid());
// Add services to the container.
builder.Services.AddControllersWithViews();



        builder.Services.AddQuartz(q =>
        {
            var jobKey = new JobKey("SendEmailJob");
            q.AddJob<EmailJob>(opts => opts.WithIdentity(jobKey));
    
            q.AddTrigger(opts => opts
                .ForJob(jobKey)
                .WithIdentity("SendEmailJob-trigger")
                .WithCronSchedule("0 * * ? * *")
            );        });

        builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
        builder.Services.AddSingleton<IJobFactory, SingletonJobFactory>();
        builder.Services.AddSingleton<EmailScheduler>();
        builder.Services.AddHostedService<Worker>();
    


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySQL(connectionString: builder.Configuration.GetConnectionString("DefaultConnection")!));

builder.Services.AddScoped<IDoctor, DoctorRepo>().
    AddScoped<IPatient, PatientRepo>().
    AddScoped<IPrescription, PrescriptionRepo>().
    AddScoped<IAppointment,AppointmentRepo>().
    AddScoped<IInventory,InventoryRepo>();

builder.Services.AddIdentity<User, IdentityRole>(opt =>
    {
        opt.Password.RequiredLength = 7;
        opt.Password.RequireDigit = false;
        opt.Password.RequireUppercase = true;
        opt.User.RequireUniqueEmail = true;
    })
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddNotyf(config =>
{
    config.DurationInSeconds = 7;
    config.IsDismissable = true;
    config.Position = NotyfPosition.TopRight;
});
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromDays(30);
    options.LoginPath = "/Auth/Login";
    options.AccessDeniedPath = "/Auth/Login";
    options.SlidingExpiration = true;
});
var app = builder.Build();
// CreateRoles(app.Services).Wait();

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

app.UseNotyf();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

async Task CreateRoles(IServiceProvider serviceProvider)
{
    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

    string[] roleNames = ["Administrator", "Doctor", "Patient"];

    foreach (var roleName in roleNames)
    {
        var roleExist = await roleManager.RoleExistsAsync(roleName);
        if (!roleExist)
        {
            await roleManager.CreateAsync(new IdentityRole(roleName));
        }
    }

    var adminUser = new User()
    {
        UserName = "admin@admin.com",
        Email = "admin@admin.com"
    };

    const string adminPassword = "Admin@123";
    var user = await userManager.FindByEmailAsync(adminUser.Email);

    if (user == null)
    {
        var createAdmin = await userManager.CreateAsync(adminUser, adminPassword);
        if (createAdmin.Succeeded)
        {
            await userManager.AddToRoleAsync(adminUser, "Administrator");
        }
    }
}