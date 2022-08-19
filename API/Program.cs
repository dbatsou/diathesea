using Microsoft.EntityFrameworkCore;
using Persistence;
using Storage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("Default") ?? "Data Source=diathesea.db";
builder.Services.AddSqlite<DataContext>(connectionString);


var app = builder.Build();

using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try 
                
                {
                    var context = services.GetRequiredService<DataContext>();
                    context.Database.Migrate();
                    await Seed.SeedData(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occured during migration");
                }
            }

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
