using NoticiasEnriquecidas.Services;
using NoticiasEnriquecidas.Data;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient<IJsonPlaceholderService, JsonPlaceholderService>();


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllers(); // API Controllers
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=feedback.db"));

var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
builder.WebHost.UseUrls($"http://*:{port}");


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
