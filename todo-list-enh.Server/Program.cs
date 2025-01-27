using Microsoft.EntityFrameworkCore;
using System;
using todo_list_enh.Server.Data;
using todo_list_enh.Server.Repositories;
using todo_list_enh.Server.Services;

var builder = WebApplication.CreateBuilder(args);

// ������ ������ �� ����������.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// ������ CORS ����� ���������� �������
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin() 
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

// Adding new service
builder.Services.AddScoped<DatabaseService>();
// Add dbContext to services
builder.Services.AddDbContext<ETLDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Adding user Repository
builder.Services.AddScoped<IUserRepository, SQLUserRepository>();

var app = builder.Build();

app.UseCors();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
