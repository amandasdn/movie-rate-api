using Microsoft.EntityFrameworkCore;
using MovieRate.Api.Extensions;
using MovieRate.Application.DependencyInjection;
using MovieRate.ExternalService.TMDB.DependencyInjection;
using MovieRate.Infra.Data;
using MovieRate.Infra.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddApplicationDependencies()
    .AddInfraDependencies()
    .AddTmdbDependencies(builder.Configuration);

builder.Services.AddDbContext<MovieRateDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
 app.UseSwaggerUI();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<MovieRateDbContext>();
    dbContext.Database.Migrate();
}

app.UseHttpsRedirection();
app.AddEndpoints();

app.Run();
