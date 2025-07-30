using AppData.Extentions;
using AppService.Extention;
using AppWeb.Extentions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddDataExtentions(builder.Configuration);
builder.Services.AddAppServices();
builder.Services.AddWebExtentions();
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenLocalhost(5131); // HTTP
    options.ListenLocalhost(7100, listenOptions =>
    {
        listenOptions.UseHttps(); // HTTPS
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404", "?code={0}");
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
