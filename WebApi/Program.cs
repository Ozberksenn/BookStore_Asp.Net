var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); // todo unutma 
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

var app = builder.Build();


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

