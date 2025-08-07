using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICnaeService, CnaeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/cnae", async (
    [FromServices] ICnaeService cnaeService,
    [FromQuery] int pageNumber = 1,
    [FromQuery] int size = 10) =>
{
    var list = await cnaeService.GetAllAsync(pageNumber, size);

    return Results.Ok(list);
})
.WithName("GetCNAEFullList")
.WithOpenApi();

await app.RunAsync();
