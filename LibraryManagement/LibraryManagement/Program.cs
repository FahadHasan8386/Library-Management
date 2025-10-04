using LM.Api.Repositories;
using LM.Api.Repositories.Interfaces;
using LM.Api.Services;
using LM.Api.Services.Interfaces;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<System.Data.IDbConnection>(sp =>
   new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));

// Service register
builder.Services.AddScoped<IBookService, BookService>();

// Repository register
builder.Services.AddScoped<IBooksRepository, BooksRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
