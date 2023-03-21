using Discount.Grpc.Data;
using Discount.Grpc.Services;
using Microsoft.EntityFrameworkCore;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddDbContext<DiscountDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DiscountConnection")));
// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddOpenTelemetryTracing(config => config
           .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("Discount Grpc"))
           .AddOtlpExporter(c =>
           {
               c.Endpoint = new Uri("http://localhost:4317");
           })
           .AddSqlClientInstrumentation(opt => opt.SetDbStatementForText = true)
           .AddAspNetCoreInstrumentation());
var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<DiscountService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
