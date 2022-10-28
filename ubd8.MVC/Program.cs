using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using upd8.MVC.Configurations;
using upd8.Data.context;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables();

builder.Services.AddDbContext<Upd8DbContext>(options =>
{

    //SQLSERVER
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

});

//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//{
//    //MYSQL
//    options.UseMySql("server=localhost;initial catalog=InterpriseStoreDb;uid=root;pwd=Root",
//    Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.0-mysql")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
//    //SQLSERVER
//    //options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

//});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddMvcConfiguration();



builder.Services.ResolveDependencies();

var app = builder.Build();

// Configure
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    //app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/erro/500");
    app.UseStatusCodePagesWithRedirects("/erro/{0}");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();




app.UseAuthentication();
app.UseAuthorization();

//app.UseGlobalizationConfig();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
