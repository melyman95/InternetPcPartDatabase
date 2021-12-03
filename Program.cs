using InternetPcPartDatabase.Data;
using InternetPcPartDatabase.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SendGrid;
using SendGrid.Helpers.Mail;

#nullable disable

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<PartContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(15);
    options.Cookie.IsEssential = true;
});

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// SendGrid
var apiKey = builder.Configuration.GetSection("SENDGRID_KEY").Value;
var client = new SendGridClient(apiKey);
var message = new SendGridMessage()
{
    From = new EmailAddress("gojem73112@terasd.com", "IPCDB"),
    Subject = "Sending Email with SendGrid",
    PlainTextContent = "It's easy to do",
    HtmlContent = "<strong> and easy to do anywhere</strong>"
};
message.AddTo(new EmailAddress("mattlyman12@gmail.com", "Matt Lyman"));
var response = await client.SendEmailAsync(message).ConfigureAwait(false);
//

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<PartContext>();
builder.Services.AddControllersWithViews();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
    options.Password.RequiredLength = 6;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

// Create the default roles
IServiceScope serviceProvider = app.Services.GetRequiredService<IServiceProvider>().CreateScope();
await IdentityHelper.CreateRoles(serviceProvider.ServiceProvider, IdentityHelper.Administrator, IdentityHelper.User);
// Now create the default admin
await IdentityHelper.CreateDefaultUser(serviceProvider.ServiceProvider, IdentityHelper.Administrator);
app.Run();
