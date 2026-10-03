var builder = WebApplication.CreateBuilder(args);

// Configure Kestrel to listen on port 8000
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(8000);
    // Also enable HTTPS on 8001 using the default development certificate
    options.ListenAnyIP(8001, listenOptions =>
    {
        listenOptions.UseHttps();
    });
});

// Add services to the container.

builder.Services.AddControllers();
// Configure Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
