using MedicalAppAPI.Data;
using MedicalAppAPI.Mapper;
using MedicalAppAPI.Repos;
using MedicalAppAPI.Repos.UserActions;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<UsersDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("MedAppConnectionString")));

builder.Services.AddDbContext<MedicalRecordDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("MedAppConnectionString")));

builder.Services.AddScoped<IUserRepositoryActions, SQLUserRepository>();
builder.Services.AddScoped<IMedicalRecordActions, SQLMedicalRecordRepository>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

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
