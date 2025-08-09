using BackendTaller.Interfaces;
using BackendTaller.Services;

var builder = WebApplication.CreateBuilder(args);

string Alloworigins = "appweb";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: Alloworigins,
        builder =>
        {
            builder.WithOrigins("http://localhost:57706/")
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
        });

});


// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSingleton<IOrder, SOrders>();

/*
builder.Services.AddTransient<IOrder, SOrders>();
builder.Services.AddScoped<IOrder, SOrders>();
builder.Services.AddSingleton<IOrder, SOrders>();
*/

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//habilitar el navigate del dominio
app.UseCors(Alloworigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
