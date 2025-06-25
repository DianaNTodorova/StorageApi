using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // <-- This line enables Swagger

// Add your DbContext, e.g.:
builder.Services.AddDbContext<StorageContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("StorageContext")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();             // <-- Show Swagger in dev
    app.UseSwaggerUI();          // <-- Show Swagger UI in browser
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
