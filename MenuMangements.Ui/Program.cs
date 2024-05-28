using MenuMangements.Ui.Components;
using MenuMangements.Ui.Services.Abstraction;
using MenuMangements.Ui.Services.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddScoped(serviceProvider =>
{
    // Get base url from appsettings.json
    var baseURL = Environment.GetEnvironmentVariable("BASE_URL") ?? builder.Configuration["BaseURL"];

    // inject httpClient with baseURL
    return new HttpClient { BaseAddress = new Uri(baseURL) };
});
builder.Services.AddScoped<IMenuService, MenuService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
