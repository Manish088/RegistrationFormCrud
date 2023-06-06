using CrudOperation1.Models;
using CrudOperation1.Repositories.Contract;
using CrudOperation1.Repositories.Implementation;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped < IGenericRepository < TblUserRegistration >, UserRegistrationRepository > ();
builder.Services.AddScoped <IGenericStateRepository< tblState >, StateRepository > ();
builder.Services.AddScoped<IGenericCityRepository<tblCity>, CityRepository>();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
