using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebSiteStartNet2023.Data;
using Microsoft.Extensions.FileProviders;
using AspNetCore.ReCaptcha;
using WebSiteStartNet2023.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.Configure<GoogleCaptchaConfig>(builder.Configuration.GetSection("GoogleReCaptcha"));
builder.Services.AddTransient(typeof(GoogleCaptchaService));

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

app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(
           Path.Combine(builder.Environment.ContentRootPath, "Data")),
    RequestPath = "/Data"
});

app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(
           Path.Combine(builder.Environment.ContentRootPath, "expire")),
    RequestPath = "/expire"
});

app.UseDeveloperExceptionPage();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "area",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.MapAreaControllerRoute("default", "ContentAdmin","{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

CreateRoles(app.Services).Wait();

app.Run();

async Task CreateRoles(IServiceProvider serviceProvider)
{
    using var scope = serviceProvider.CreateScope();
    using var RoleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    using var UserManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

    IdentityResult roleResult;
    //here in this line we are adding Admin Role
    var roleCheck = await RoleManager.RoleExistsAsync("Admin");
    if (!roleCheck)
    {
        //here in this line we are creating admin role and seed it to the database
        roleResult = await RoleManager.CreateAsync(new IdentityRole("Admin"));
    }
    //here we are assigning the Admin role to the User that we have registered above 
    //Now, we are assinging admin role to this user("Ali@gmail.com"). When will we run this project then it will
    //be assigned to that user.
    IdentityUser user = await UserManager.FindByEmailAsync("admin@gmail.com");
    var User = new IdentityUser();
    await UserManager.AddToRoleAsync(user, "Admin");
}