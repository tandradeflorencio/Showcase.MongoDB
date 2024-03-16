using Showcase.MongoDB.Repositories;
using Showcase.MongoDB.Repositories.Interfaces;
using Showcase.MongoDB.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ICustomerRepository, CustomerRepository>();

builder.Services.Configure<ShowcaseDatabaseSettings>(builder.Configuration.GetSection("ShowcaseDatabase"));

builder.Services.AddControllers().
    AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/customers", async (ICustomerRepository repository) =>
{
    var result = await repository.ListAsync();

    return Results.Ok(result);
})
.WithName("GetCustomers")
.WithOpenApi();

app.Run();