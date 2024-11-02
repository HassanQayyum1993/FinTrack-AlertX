using FinTrack.AlertX.Data;
using FinTrack.AlertX.Repositories;
using FinTrack.AlertX.Services;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add SQL Server and MongoDB
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));
builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(builder.Configuration.GetConnectionString("MongoDB")));

// Register services and repositories
builder.Services.AddScoped<UserPreferencesRepository>();
builder.Services.AddScoped<NotificationRepository>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddSingleton<MessageQueueService>();

// Add controllers
builder.Services.AddControllers();

// Add Swagger services
builder.Services.AddEndpointsApiExplorer(); // Required for API Explorer
builder.Services.AddSwaggerGen(); // Register Swagger generator

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Enable middleware to serve generated Swagger as a JSON endpoint.
app.UseSwagger();

// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "FinTrack AlertX API V1");
    c.RoutePrefix = string.Empty; // Set the Swagger UI at the app's root
});

app.MapControllers();
app.Run();
