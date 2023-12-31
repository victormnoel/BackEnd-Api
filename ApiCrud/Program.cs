using ApiCrud.Context;
using ApiCrud.InfraData;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<UserContext>(options => options.UseMySql("Server=localhost;Database=crud;userId=root;password=root;"
, ServerVersion.Parse("8.0.29-mysql")));

builder.Services.AddScoped<IBaseInfraData, BaseInfraData>();
builder.Services.AddScoped<IUserInfraData, UserInfraData>();

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
