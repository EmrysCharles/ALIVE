using Alive.Config;
using Alive.data;
using Alive.Helpers;
using Alive.IHelpers;
using Alive.Models;
using Alive.SmtpMailServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IUserHelper, UserHelper>();
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("AliveTB")));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 3;
    options.Password.RequiredUniqueChars = 0;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;

}).AddEntityFrameworkStores<AppDbContext>();


builder.Services.AddSingleton<IEmailConfiguration>(builder.Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>());
builder.Services.AddTransient<IEmailService, EmailService>();


builder.Services.AddScoped<IUserHelper, UserHelper>();
builder.Services.AddScoped<IDropdownhelper, Dropdownhelper>();
builder.Services.AddScoped<IEmailHelper, EmailHelper>();


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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
