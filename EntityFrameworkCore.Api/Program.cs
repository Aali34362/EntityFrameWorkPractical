using EntityFrameworkCore.Api.Extension;
using EntityFrameWorkCore.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options => 
    { 
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


//var connectionString = builder.Configuration.GetConnectionString("SqlDatabaseConnectionString");
var sqliteDatabaseName = builder.Configuration.GetConnectionString("SqliteDatabaseConnectionString");
var folder = Environment.SpecialFolder.LocalApplicationData;
var path = Environment.GetFolderPath(folder);
Console.WriteLine(path);
var dbPath = Path.Combine(path, sqliteDatabaseName);
Console.WriteLine(dbPath);
var connectionString = $"Data Source = {dbPath}";

builder.Services.AddDbContext<FootballLeagueApiDBContext>(options =>
{
    options.UseSqlite(connectionString, sqliteOptions => {
        //sqliteOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
        sqliteOptions.CommandTimeout(30);
    })
    //.UseSqlServer(builder.Configuration.GetConnectionString("SqlDatabaseConnectionString"))
        //.UseLazyLoadingProxies()
        .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
        .LogTo(Console.WriteLine, LogLevel.Information)
        ;
    if(!builder.Environment.IsProduction())
    {
        options.EnableSensitiveDataLogging();
        options.EnableDetailedErrors();
    }
});


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
