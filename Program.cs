
using DesafioBtg.Consumers;
using DesafioBtg.Interfaces;
using DesafioBtg.Services;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IPedidoInterface, PedidoService>();

//Registro do consumidor e configuração da fila
builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<ConsumidorPedidos>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(new Uri("amqp://localhost:5672"));

        cfg.ReceiveEndpoint("fila-pedidos", e =>
        {
            e.ConfigureConsumer<ConsumidorPedidos>(context);
        });
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
