using Microsoft.EntityFrameworkCore;
using Storage;
using MediatR;
using Application.States;
using Application.Core;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

const string CORSPolicy = "CorsPolicy";
// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddControllers().AddJsonOptions(jsonOptions =>
                {
                    jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = null;
                    jsonOptions.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;

                });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
builder.Services.AddMediatR(typeof(List.Query).Assembly);
builder.Services.AddAutoMapper(typeof(MappingProfiles).Assembly);


var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddSqlite<DataContext>(connectionString);

builder.Services.AddCors(opt =>
            {
                opt.AddPolicy(CORSPolicy, policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000");
                });
            });


var app = builder.Build();
app.UseCors(CORSPolicy);


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    await RecreateDatabase();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.Run();



async Task RecreateDatabase()
{

    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        try
        {
            string[] fileNames = new string[]
            {
            "diathesea.db",
            "diathesea.db-wal",
            "diathesea.db-shm",
            };

            foreach (string file in fileNames)
                if (File.Exists(file))
                    File.Delete(file);

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
}