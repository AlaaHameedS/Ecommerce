using Ecommerce.Data;
using Ecommerce.Data.Services;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddScoped<ICategoryServices,CategoryServices>();
builder.Services.AddScoped<IProductServices,ProductServices>();

//builder.Services.Configure<RazorViewEngineOptions > (options =>
//{
//    options.ViewLocationFormats.Add("/NotFound/{1}/{0}.cshtml");
//    options.ViewLocationFormats.Add("/NotFound/Shared/{0}.cshtml");
//});
 
builder.Services.AddDbContext<EcommerceDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefultConnection")));


var app = builder.Build();

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
    pattern: "{controller=Products}/{action=Index}/{id?}");

AppDbInitializer.Seed(app);


app.Run();
