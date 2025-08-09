using CallApi;

/*

sc.exe create "Nombre del servicio" bindpath = "mi folder\nombredelservicio.exe" 

 */


var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddWindowsService(options =>
{
    options.ServiceName = "taller service";
});


builder.Services.AddHostedService<Worker>();
builder.Services.AddHostedService<Worker2>();


var host = builder.Build();
host.Run();
