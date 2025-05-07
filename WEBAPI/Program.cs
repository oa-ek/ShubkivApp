using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Repository;
using WebApi.Repository.Interfaces;
using ShubkivTour.Repository;

var builder = WebApplication.CreateBuilder(args);

// ������ DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

/*builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7205/")
});*/


// �������� ���������
builder.Services.AddScoped<ITour, TourRepository>();
builder.Services.AddScoped<IGuide, GuideRepository>();
builder.Services.AddScoped<ILocation, LocationRepository>();
builder.Services.AddScoped<IEntertainment, EntertainmentRepository>();
builder.Services.AddScoped<ITourProgram, TourProgramRepository>();


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

builder.Services.AddCors();
app.UseCors(policy =>
    policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
