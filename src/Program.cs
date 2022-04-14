using Interfaces;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IUniversityApiService, UniversityApiService>();
builder.Services.AddScoped<IScheduleService, ScheduleService>();
builder.Services.AddScoped<IActivitiesService, ActivitiesService>();
var cachePath = Path.Combine(Directory.GetCurrentDirectory(), "cache");
if (!Directory.Exists(cachePath))
{
    Directory.CreateDirectory(cachePath);
}

var fileService = new FileService(cachePath);

builder.Services.AddSingleton<FileService>(fileService);

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

