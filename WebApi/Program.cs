using System.Reflection;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); // todo unutma 
builder.Services.AddSwaggerGen();
builder.Services.AddOpenApi();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddDbContext<BookStoreDbContext>(options =>
    options.UseInMemoryDatabase("BookStoreDB"));


var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    DataGenerator.Initialize(services); // veritabanını başlatır

}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(); // arayüzü açar
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

