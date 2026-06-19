using Microsoft.EntityFrameworkCore;
using CyfrowaBiblioteka.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BibliotekaContext>(opcje =>
    opcje.UseSqlite(builder.Configuration.GetConnectionString("Baza")));

var app = builder.Build();

// utworzenie bazy danych przy starcie (razem z danymi startowymi)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<BibliotekaContext>();
    db.Database.EnsureCreated();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
