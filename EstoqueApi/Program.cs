using EstoqueApi.Features;
using EstoqueApi.Repositories;
using EstoqueApi.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

builder.Services.AddScoped<ProdutoRepository>();
builder.Services.AddScoped<EstoqueRepository>();
builder.Services.AddScoped<MovimentacaoEstoqueRepository>();
builder.Services.AddScoped<LogErroRepository>();

builder.Services.AddScoped<ListarProdutosQueryHandler>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<ListarProdutosQueryHandler>());

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LogErrorMiddleware<,>));


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
