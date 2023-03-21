using Discount.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddDbContext<DiscountDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DiscountConnection")));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Discount.API", Version = "v1" });
});
builder.Services.AddOpenTelemetryTracing(config => config
           .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("Discount"))
           .AddOtlpExporter(c =>
           {
              c.Endpoint= new Uri("http://localhost:4317");
           })
           .AddSqlClientInstrumentation(opt => opt.SetDbStatementForText = true)
           .AddAspNetCoreInstrumentation());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Discount.API v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
