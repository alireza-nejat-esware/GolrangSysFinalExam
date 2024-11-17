using DocumentFormat.OpenXml.Spreadsheet;
using GolrangSystemFinalExam.Core.Interfaces;
using GolrangSystemFinalExam.Infrastructure.Data;
using GolrangSystemFinalExam.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.ConfigureServices(configuration);

var connectionString = builder.Configuration.GetConnectionString("FinalExamDbConnection") ?? throw new InvalidOperationException("Connection string 'FinalExamDbConnection' not found.");
builder.Services.AddDbContext<GolrangSystemFinalExamDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IDiscountRepository, DiscountRepository>();
builder.Services.AddScoped<IPreInvoiceDetailsRepository, PreInvoiceDetailsRepository>();
builder.Services.AddScoped<IPreInvoiceHeaderRepository, PreInvoiceHeaderRepository>();
builder.Services.AddScoped<ISellLineProductRepository, SellLineProductRepository>();
builder.Services.AddScoped<ISellLineSellerRepository, SellLineSellerRepository>();

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
