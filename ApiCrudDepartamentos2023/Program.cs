using ApiCrudDepartamentos2023.Data;
using ApiCrudDepartamentos2023.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
string connectionString = builder.Configuration.GetConnectionString("sqlhospital");
builder.Services.AddTransient<RepositoryDepartamentos>();
builder.Services.AddDbContext<DepartamentosContext>
    (options => options.UseSqlServer(connectionString));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    options => {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Api Departamentos CRUD 2023",
            Version = "v1"
        });
    });


var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiDepartamentosCRUD 2023 v1");
    options.RoutePrefix = "";
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
