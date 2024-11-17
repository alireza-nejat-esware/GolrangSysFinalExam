using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using DocumentFormat.OpenXml.Spreadsheet;
using GolrangSystemFinalExam.Core.Interfaces;
using GolrangSystemFinalExam.Infrastructure.Data;
using GolrangSystemFinalExam.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("FinalExamDbConnection") ?? throw new InvalidOperationException("Connection string 'FinalExamDbConnection' not found.");
builder.Services.AddDbContext<GolrangSystemFinalExamDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IDiscountRepository, DiscountRepository>();
builder.Services.AddScoped<IPreInvoiceDetailsRepository, PreInvoiceDetailsRepository>();
builder.Services.AddScoped<IPreInvoiceHeaderRepository, PreInvoiceHeaderRepository>();
builder.Services.AddScoped<ISellLineProductRepository, SellLineProductRepository>();
builder.Services.AddScoped<ISellLineSellerRepository, SellLineSellerRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "ToDo API",
        Description = "An ASP.NET Core Web API",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });
});
//builder.Services.ConfigureServices(configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
