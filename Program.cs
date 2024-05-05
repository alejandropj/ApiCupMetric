using ApiCupMetric.Data;
using ApiCupMetric.Helpers;
using ApiCupMetric.Repositories;
using Azure.Security.KeyVault.Secrets;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Azure;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

//KeyVault
builder.Services.AddAzureClients(factory =>
{
    factory.AddSecretClient
    (builder.Configuration.GetSection("KeyVault"));
});
SecretClient secretClient =
builder.Services.BuildServiceProvider().GetService<SecretClient>();


KeyVaultSecret secret =
    await secretClient.GetSecretAsync("SqlAzure");
KeyVaultSecret audienceKey = await secretClient.GetSecretAsync("Audience");
KeyVaultSecret issuerKey = await secretClient.GetSecretAsync("Issuer");
KeyVaultSecret secretKey = await secretClient.GetSecretAsync("SecretKey");

string connectionString = secret.Value;
string secretKeyValue = secretKey.Value;
string audience = audienceKey.Value;
string issuer = issuerKey.Value;


//Creamos una instancia del helper
HelperActionOAuth helper = new HelperActionOAuth
    (secretKeyValue, audience,issuer);

builder.Services.AddSingleton<HelperActionOAuth>(helper);

builder.Services.AddAuthentication
    (helper.GetAuthenticateSchema())
    .AddJwtBearer(helper.GetJwtBearerOptions());

// Add services to the container.
//string connectionString = builder.Configuration.GetConnectionString("SqlAzure");
builder.Services.AddTransient<RepositoryIngredientes>();
builder.Services.AddTransient<RepositoryReceta>(provider => new RepositoryReceta(provider.GetRequiredService<CupMetricContext>(), connectionString));
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
}
    app.UseSwagger();
    app.UseSwaggerUI(
        options =>
        {
            options.SwaggerEndpoint(url: "/swagger/v1/swagger.json",
                name: "CUPMETRIC API");
            options.RoutePrefix = "";
        });

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
