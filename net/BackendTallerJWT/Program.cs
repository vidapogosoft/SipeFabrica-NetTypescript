using BackendTaller.Interfaces;
using BackendTaller.Services;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
    
var builder = WebApplication.CreateBuilder(args);

var key = "Demo Token Apikey Example para backend";

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddAuthentication(
    
    x=> { x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(
    x=>
    {
        x.SaveToken = true;
        x.RequireHttpsMetadata = false;

        x.TokenValidationParameters = new TokenValidationParameters
        {
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            ValidateIssuer = false,
            ValidateLifetime = true
        };

    });

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddAuthorization();

builder.Services.AddSingleton<IJwt>(new SJwt(key));
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
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
