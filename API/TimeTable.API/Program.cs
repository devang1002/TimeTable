using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TimeTable.Infra.Context;
using TimeTable.Infra.Extensions;
using TimeTable.Services.Extensions;
using TimeTable.Services.Mapper;


var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;
// Add services to the container.




builder.Services.AddMvc();
builder.Services.TimeTableInfraServiceRegistration(builder.Configuration);
builder.Services.TimeTableInfraService();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = false; // Ensures clean output
    options.JsonSerializerOptions.PropertyNamingPolicy = null; // Prevents automatic property renaming
});




builder.Services.AddMemoryCache();

builder.Services.AddControllers();
    

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Default Policy
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.AllowAnyHeader();
            builder.AllowAnyMethod();
            builder.AllowAnyOrigin();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors();

app.UseStaticFiles();

app.Run();
