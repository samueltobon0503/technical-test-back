using CleanArch.API;
using CleanArch.Application;
using CleanArch.External;
using CleanArch.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services
    .AddWebApi()
    .AddApplication()
    .AddExternal()
    .AddPersistence(builder.Configuration);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});
app.UseCors("AllowAll");
app.MapControllers();
app.Run();
