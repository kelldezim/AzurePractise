using Azure.Practise.Configuration.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Configuration.AddAzureAppConfiguration(options =>
{
    options.Connect(builder.Configuration.GetConnectionString("AzureAppConfiguration"));
    options.ConfigureRefresh(refresh =>
    {
        refresh
            .Register("refreshAll", refreshAll: true)
            .SetCacheExpiration(TimeSpan.FromSeconds(5));
    });
});
builder.Services.AddAzureAppConfiguration();
builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.AddOptions(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAzureAppConfiguration();

app.UseAuthorization();

app.MapControllers();

app.Run();
