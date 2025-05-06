using ShubkivApp.Components;
using ShubkivApp.Repository;
using ShubkivApp.Repository.Interfaces;
using ShubkivTour.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<ITour, TourRepository>();
builder.Services.AddScoped<IGuide, GuideRepository>();
builder.Services.AddScoped<ILocation, LocationRepository>();
builder.Services.AddScoped<IEntertainment, EntertainmentRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
