using DRMusicREST.DBContext;
using DRMusicREST.Interfaces;
using DRMusicREST.Models;
using DRMusicREST.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAll",
                              policy =>
                              {
                                  policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(x => true);
                              });
});

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
//builder.Services.AddSingleton<IRepository<MusicRecord>, MusicRecordRepository>();
builder.Services.AddScoped<IRepository<MusicRecord>, MusicRecordDbRepo>();
// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MusicRecordDbContext>(options =>
{
    var connectionString =
        builder.Configuration.GetConnectionString("MusicRecordDB")
        ?? throw new InvalidOperationException(
            "Connection string 'MusicRecordDB' was not found.");

    options.UseSqlServer(connectionString);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
