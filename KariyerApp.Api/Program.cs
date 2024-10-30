using KariyerApp.Core;
using Microsoft.EntityFrameworkCore;
using KariyerApp.Api.Profiles;
using KariyerApp.BusinessLogic.Interfaces;
using KariyerApp.BusinessLogic;
using KariyerApp.Core.Interfaces;
using KariyerApp.Data.Repositories;
using KariyerApp.BusinessLogic.Services;
using KariyerApp.DataAccess.Interfaces;
using KariyerApp.DataAccess.Repositories;
using System.Text.Json.Serialization;
using Nest;
using KariyerApp.Core.Entities;

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var builder = WebApplication.CreateBuilder(args);

// Connection string'i appsettings.json'dan alın
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve; // Döngüsel referanslar için ayar
    options.JsonSerializerOptions.MaxDepth = 64; // Gerekirse derinliği artırın
});

// Entity Framework Core'u yapılandırın
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

// Diğer servisler
var settings = new ConnectionSettings(new Uri("http://localhost:9200"));

var client = new ElasticClient(settings);
builder.Services.AddSingleton(client);
builder.Services.AddScoped<IElasticSearchService, ElasticSearchService>();

// Repository ve Service'leri kaydedin
builder.Services.AddScoped<IRecruiterRepository, RecruiterRepository>();
builder.Services.AddScoped<IRecruiterService, RecruiterService>();
// Diğer servisleri burada ekleyin

builder.Services.AddScoped<IJobAdvertisementRepository, JobAdvertisementRepository>();
builder.Services.AddScoped<IJobAdvertisementService, JobAdvertisementService>();

// AutoMapper'ı yapılandırın
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Swagger'ı yapılandırın
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware'leri ekleyin
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Diğer middleware'leri burada ekleyin
app.UseHttpsRedirection();
app.UseAuthorization();

// Endpoint'leri tanımlayın
app.MapControllers();

app.Run();