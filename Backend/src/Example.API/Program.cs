using Example.API.Endpoints.Cities;
using Example.API.Endpoints.Persons;
using Example.Application.ExampleService.Models.Request;
using Example.Application.ExampleService.Service;
using Example.Infra.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSqlServer<ApplicationDbContext>(
    builder.Configuration["ConnectionStrings:DefaultConnection"], options => options.EnableRetryOnFailure());





// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



builder.Services.AddCors();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapMethods(CityGetAll.Template, CityGetAll.Methods, CityGetAll.Handle);
app.MapMethods(PersonDelete.Template, PersonDelete.Methods, PersonDelete.Handle);
app.MapMethods(PersonGetAll.Template, PersonGetAll.Methods, PersonGetAll.Handle);
app.MapMethods(PersonGetById.Template, PersonGetById.Methods, PersonGetById.Handle);
app.MapMethods(PersonPost.Template, PersonPost.Methods, PersonPost.Handle);
app.MapMethods(PersonPut.Template, PersonPut.Methods, PersonPut.Handle);

app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});
app.UseAuthorization();

app.Run();

