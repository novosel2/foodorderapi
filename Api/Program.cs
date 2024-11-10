using Api.StartupExtensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureServices(builder.Configuration);

builder.Host.UseSerilog((HostBuilderContext context, IServiceProvider services, LoggerConfiguration loggerConfiguration) =>
{
    loggerConfiguration
    .ReadFrom.Configuration(context.Configuration)
    .ReadFrom.Services(services);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHsts();
app.UseHttpsRedirection();

app.UseResponseCaching();

app.UseRouting();
app.MapControllers();

app.Run();