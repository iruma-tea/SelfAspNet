using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using SelfAspNet.Filters;
using SelfAspNet.Helpers;
using SelfAspNet.Lib;
using SelfAspNet.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(options =>
{
    options.ValueProviderFactories.Add(new HttpCookieValueProviderFactory());
    // options.ModelBinderProviders.Insert(0, new DateModelBinderProvider());
    // options.Filters.Add<MyLogAttribute>(); // MyLogAttributeのフィルターをアプリ単位に指定
});

// builder.Services.AddDbContext<MyContext>(options => options.UseLazyLoadingProxies().UseSqlite(
builder.Services.AddDbContext<MyContext>(options => options.UseSqlite(
    builder.Configuration.GetConnectionString("MyContext")
));

builder.Services.AddSingleton<ITagHelperInitializer<ScriptTagHelper>, ScriptTagHelperInitializer>();
builder.Services.AddTransient<ITagHelperComponent, MetaTagHelperComponent>();

builder.Services.Configure<KestrelServerOptions>(options =>
{
    options.AllowSynchronousIO = true;
});

// builder.WebHost.ConfigureKestrel(opts =>
// {
//     opts.Limits.MaxRequestBodySize = 1024 * 1024 * 55;
// });

var app = builder.Build();

// DB Initialize
// using (var scope = app.Services.CreateScope())
// {
//     var provider = scope.ServiceProvider;
//     Seed.Initialize(provider);
// }

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
