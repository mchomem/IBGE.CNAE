var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.MapGet("/api/cnaes", async (ICnaeService cnaeService) =>
{
    string directory = Path.Combine(AppContext.BaseDirectory, "Data");

    if (!Directory.Exists(directory))
        return Results.NotFound("Directory not found.");

    // Busca o primeiro arquivo .xlsx no diretório
    var filePath = Directory.GetFiles(directory, "*.xlsx").FirstOrDefault();

    if (filePath == null)
        return Results.NotFound("Excel file not found.");

    var list = await cnaeService.ExcelReader(filePath);

    return Results.Ok(list);
})
.WithName("GetCNAEFullList")
.WithOpenApi();

await app.RunAsync();
