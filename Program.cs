using HajurKoCarRental.Lib.Blood;
using HajurKoCarRental.Lib.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.InitializeDependencies();

var app = builder.Build();

app.AddAppMappings();
app.AddDevHelperPages();

app.UseHttpsRedirection();

app.Run();