using Microsoft.AspNetCore.Antiforgery;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddAntiforgery(options => options.HeaderName = "X-XSRF-TOKEN");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

var antiForgery = app.Services.GetRequiredService<IAntiforgery>();

app.Use((context, next) =>
{
    var path = context.Request.Path.Value;
    if (path == null || !string.Equals(path, "/", StringComparison.OrdinalIgnoreCase) &&
        !string.Equals(path, "/index.html", StringComparison.OrdinalIgnoreCase) &&
        !path.Contains("/api/", StringComparison.OrdinalIgnoreCase))
    {
        return next(context);
    }

    var tokens = antiForgery.GetAndStoreTokens(context);
    context.Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken, 
        new CookieOptions { HttpOnly = false });

    return next(context);
});


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();