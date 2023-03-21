using Basket.API.GrpcServices;
using Basket.API.Repositories;
using Discount.Grpc.Protos;
using MassTransit;
using Microsoft.OpenApi.Models;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddScoped<IBasketRepository, BasketRepository>();
builder.Services.AddScoped<DiscountGrpcService>();
// AutoMapper
builder.Services.AddAutoMapper(typeof(Program));
// Redis Configuration
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = configuration.GetValue<string>("CacheSettings:ConnectionString");
});
// MassTransit-RabbitMQ Configuration
builder.Services.AddMassTransit(config => {
    config.UsingRabbitMq((ctx, cfg) => {
        cfg.Host(configuration["EventBusSettings:HostAddress"]);
    });
});
builder.Services.AddOpenTelemetryTracing(config => config
           .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("Basket"))
           .AddOtlpExporter(c =>
           {
               c.Endpoint = new Uri("http://localhost:4317");
           })
           .AddSqlClientInstrumentation(opt => opt.SetDbStatementForText = true)
           .AddAspNetCoreInstrumentation());
// grpc client configuration
builder.Services.AddGrpcClient<DiscountProtoService.DiscountProtoServiceClient>
                       (o => o.Address = new Uri(configuration["GrpcSettings:DiscountUrl"]));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Basket.API", Version = "v1" });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Basket.API v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
