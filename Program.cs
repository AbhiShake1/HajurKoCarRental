using HajurKoCarRental.Lib.Blood;
using HajurKoCarRental.Lib.Extensions;
using SurrealDB;

var client = new SurrealClient("localhost", "surreal", "password", "localhost", "HajurKoCarRental");

var builder = WebApplication.CreateBuilder(args);

builder.InitializeDependencies();

var app = builder.Build();

app.AddAppMappings();
app.AddDevHelperPages();

app.UseHttpsRedirection();

app.Run();