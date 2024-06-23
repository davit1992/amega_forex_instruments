using System.Text.Json.Serialization;
using System.Text.Json;
using Amega.Service.Services.SignalR;
using Amega.Service.IServicies.SignalR;
using Amega.Service.Services.ExternalApi;
using Amega.Service.Configuration.Tiingo;
using Amega.Service.IServicies.ExternalApi;
using Amega.Service.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region SigalR
builder.Services.AddSignalR(options =>
 {
     options.EnableDetailedErrors = true;
     options.SupportedProtocols = new List<string> { "http", "https", "ws", "wss", "json" };
 }).AddJsonProtocol(option =>
   {
       option.PayloadSerializerOptions.WriteIndented = true;
       option.PayloadSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
       option.PayloadSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
       option.PayloadSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
   });
builder.Services.AddSingleton<IMessagingService, MessagingService>();
builder.Services.AddSingleton<TradeConfiguration>(builder.Configuration.GetSection("TradeConfiguration").Get<TradeConfiguration>());
#endregion
builder.Services.AddTransient<ITradeWsConnection, TradeWsConnection>();
builder.Services.AddTransient<ITradeService, TradeService>();
builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHub<UserHub>("/hubs/user", config => { });
});

app.MapControllers();

var appLifetime = app.Services.GetService<IHostApplicationLifetime>();
var tiingoConnectionService = app.Services.GetService<ITradeWsConnection>()!;
appLifetime?.ApplicationStarted.Register(async () =>
{
    await tiingoConnectionService.ConnectSocketAsync();
});

app.Run();
