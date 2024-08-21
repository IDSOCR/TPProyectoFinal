using Neo4jClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Configuración de Neo4j
builder.Services.AddSingleton<IGraphClient>(provider =>
{
    var client = new BoltGraphClient(
        builder.Configuration["Neo4j:Uri"],
        builder.Configuration["Neo4j:User"],
        builder.Configuration["Neo4j:Password"]);
    client.ConnectAsync().Wait();
    return client;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
