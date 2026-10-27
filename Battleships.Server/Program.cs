using Battleships.Server.GamePlay;
using Microsoft.AspNetCore.HttpLogging;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<GameStore>();

builder.Services.ConfigureHttpJsonOptions(options =>
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter()));
builder.Services.AddControllers()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
builder.Services.AddHttpLogging(options =>
{
    options.LoggingFields = HttpLoggingFields.RequestProperties | 
                            HttpLoggingFields.RequestBody |
                            HttpLoggingFields.ResponseStatusCode | 
                            HttpLoggingFields.ResponseBody;
    options.MediaTypeOptions.AddText("application/problem+json");
    options.RequestBodyLogLimit = 256;
    options.ResponseBodyLogLimit = 256;
    options.CombineLogs = true;
});
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpLogging();
app.MapOpenApi();
app.MapControllers();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/openapi/v1.json", "Battleships API v1");
});
app.Run();