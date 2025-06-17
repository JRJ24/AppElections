using Microsoft.EntityFrameworkCore;
using Sadvo.Persistence.Context;
using Sadvo.IOC.Dependancies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnections");
builder.Services.AddDbContext<AppElectionsContext>(opt => opt.UseSqlServer(connectionString));

builder.Services.AddCandidatosDependancy();
builder.Services.AddAliancePoliticalDependancy();
builder.Services.AddPoliticalLeaderDependancy();
builder.Services.AddPartyPoliticalDependancy();
builder.Services.AddElectivePositionsDependancy();
builder.Services.AddCitizensDepedancy();
builder.Services.AddRolesDependancy();
builder.Services.AddRolUserDependancy();
builder.Services.AddUsersDependancy();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
