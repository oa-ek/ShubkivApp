using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Repository;
using WebApi.Repository.Interfaces;
using ShubkivTour.Repository;

var builder = WebApplication.CreateBuilder(args);

// Додаємо DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Реєструємо репозиторії
builder.Services.AddScoped<ITour, TourRepository>();
builder.Services.AddScoped<IGuide, GuideRepository>();
builder.Services.AddScoped<ILocation, LocationRepository>();
builder.Services.AddScoped<IEntertainment, EntertainmentRepository>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
