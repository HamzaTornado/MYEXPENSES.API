using Microsoft.EntityFrameworkCore;
using MYEXPENSES.API.Models;
using MYEXPENSES.API.Services;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("MyExpensesConnection") ?? throw new InvalidOperationException("Connection string 'MyExpensesConnection' not found.");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//AutoMapper configuration
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Application Db Context Configuration with SqlServer
builder.Services.AddDbContext<MyExpensesContext>(
    options => options.UseSqlServer(connectionString)
);
// adding my services
builder.Services.AddScoped<BalanceService>();


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
