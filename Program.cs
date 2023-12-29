using BulkyBookWebApp.Data;
using Microsoft.EntityFrameworkCore;


//using MySQL.Data.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//=====start sqlDatabasecon=======
//builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
//builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
//   builder.Configuration.GetConnectionString("DefaultConnection")
//    )) ;

//=====End sqlDatabasecon=======

//=====start MysqlDatabasecon=======
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(
    builder.Configuration.GetConnectionString("DefaultConnection"),
   new MySqlServerVersion(new Version(8, 0, 26))
));
//=====End MysqlDatabasecon=======


var app = builder.Build();

//builder.Services.AddRazorPages().AddRazorRuntimeCompilation();



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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
