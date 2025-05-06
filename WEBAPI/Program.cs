using WebApi.Repository.Interfaces;
using WebApi.Repository;
using ShubkivTour.Repository;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<ITour, TourRepository>();
builder.Services.AddScoped<IGuide, GuideRepository>();
builder.Services.AddScoped<ILocation, LocationRepository>();
builder.Services.AddScoped<IEntertainment, EntertainmentRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
