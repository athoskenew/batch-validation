using api.DataContext;
using api.Service.BatchService;
using api.Service.MaterialService;
using api.Service.QualityService.QualityCharacteristics;
using api.Service.QualityService.QualityVision;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IMaterialInterface, MaterialService>();
builder.Services.AddScoped<IQualityCharacteristicsInterface, QualityCharacteristicsService>();
builder.Services.AddScoped<IQualityVisionInterface, QualityVisionService>();
builder.Services.AddScoped<IBatchServiceInterface, BatchService>();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("BatchValidationApp", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("BatchValidationApp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
