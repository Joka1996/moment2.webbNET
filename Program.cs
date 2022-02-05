var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews(); //aktivera MVC


builder.Services.AddDistributedMemoryCache();

//inkludera sessions
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


var app = builder.Build();

app.UseStaticFiles(); // statiska filer wwwroot
app.UseRouting(); // för routing

//ta bort id som inte ska användas i denna uppgift
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}" //home controllers
);

//aktivera sessions
app.UseSession();

app.Run();
