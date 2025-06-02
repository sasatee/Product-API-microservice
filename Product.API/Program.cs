using Core;
using Core.Mappers;
using Ecommerce.API.Middlewares;
using FluentValidation.AspNetCore;
using Infrastructure;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);




//Add Core and Infrastructure
builder.Services.AddCore();
builder.Services.AddInfrastructure(builder.Configuration);


//Add automapper profile from assembly
builder.Services.AddAutoMapper(typeof(ProductResponseMappingProfile).Assembly);


builder.Services.AddControllers();

//FluentValidations
builder.Services.AddFluentValidationAutoValidation();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:4200")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

//Middleware exceptions
app.UseExceptionHandlingMiddleware();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseCors();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
