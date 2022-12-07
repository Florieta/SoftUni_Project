using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RentalCarManagementSystem.Infrastructure.Data;
using RentalCarManagementSystem.Infrastructure.Models.Identity;
using RentalCarManagementSystem.Core.Constants;
using RentalCarManagementSystem.Web.DataBinders;
using RentalCarManagementSystem.Core.Contracts;
using RentalCarManagementSystem.Core.Services;
using RentalCarManagementSystem.Infrastructure.Data.Common;
using RentalCarManagementSystem.Core.Contracts.Admin;
using RentalCarManagementSystem.Core.Services.Admin;
using RentalCarManagementSystem.Core.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();


builder.Services.AddControllersWithViews()
     .AddMvcOptions(options =>
     {
         options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
         //options.ModelBinderProviders.Insert(1, new DateTimeModelBinderProvider(FormatingConstants.DateAndTime));
     });

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Identity/Account/Logout";
});

builder.Services.AddAutoMapper(typeof(UserMapping));

builder.Services.AddScoped<ICarService, CarService>()
    .AddScoped<IRepository, Repository>()
    .AddScoped<IBookingService, BookingService>()
    .AddScoped<ICarServiceAdmin, CarServiceAdmin>()
    .AddScoped<IUserServiceAdmin, UserServiceAdmin>()
    .AddScoped<IScheduleService, ScheduleService>()
    .AddScoped<IProfileServiceAdmin, ProfileServiceAdmin>()
    .AddScoped<ICategoryServiceAdmin, CategoryServiceAdmin>()
    .AddScoped<ILocationServiceAdmin, LocationServiceAdmin>()
    .AddScoped<IInsuranceServiceAdmin, InsuranceServiceAdmin>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
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

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

    endpoints.MapControllerRoute(
      name: "default",
      pattern: "{controller=Home}/{action=Index}/{id?}"
    );

    endpoints.MapRazorPages();
});

app.UseResponseCaching();

app.Run();
