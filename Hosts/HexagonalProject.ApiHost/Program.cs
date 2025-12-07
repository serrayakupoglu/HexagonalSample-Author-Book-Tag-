using HexagonalSample.Application.DependencyResolvers;
using HexagonalSample.Persistence.DependencyResolvers;
using HexagonalSample.WebApi.Controllers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddApplicationPart(typeof(ProductController).Assembly);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextService(builder.Configuration);
builder.Services.AddRepositoryService();
builder.Services.AddApplicationServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
