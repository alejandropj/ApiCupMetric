using ApiCupMetric.Data;
using ApiCupMetric.Helpers;
using ApiCupMetric.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

//Creamos una instancia del helper
HelperActionOAuth helper = new HelperActionOAuth
    (builder.Configuration);

builder.Services.AddSingleton<HelperActionOAuth>(helper);

builder.Services.AddAuthentication
    (helper.GetAuthenticateSchema())
    .AddJwtBearer(helper.GetJwtBearerOptions());

// Add services to the container.

string connectionString = builder.Configuration.GetConnectionString("SqlAzure");
builder.Services.AddTransient<RepositoryIngredientes>();
builder.Services.AddTransient<RepositoryReceta>();
builder.Services.AddTransient<RepositoryUsers>();
builder.Services.AddTransient<RepositoryUtensilios>();

builder.Services.AddDbContext<CupMetricContext>
    (options => options.UseSqlServer(connectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "CupMetric API",
            Description = "API con token de seguridad"
        });
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(
        options =>
        {
            options.SwaggerEndpoint(url: "/swagger/v1/swagger.json",
                name: "CUPMETRIC API");
            options.RoutePrefix = "";
        });
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
