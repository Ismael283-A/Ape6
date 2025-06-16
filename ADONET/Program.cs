using ADONET.Data;

using ADONET.Repositories;

using ADONET.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<DbConnection>();
builder.Services.AddSingleton<ProductoRepository>();
builder.Services.AddSingleton<ProductoService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// HABILITAR CORS 
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => policy
            .AllowAnyOrigin()   // También puedes especificar "http://127.0.0.1:5500" para más seguridad 
            .AllowAnyHeader()
            .AllowAnyMethod());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// APLICAR CORS 
app.UseCors("AllowFrontend");

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();