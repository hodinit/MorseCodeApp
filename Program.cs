using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MorseCodeApp2.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Users");
    options.Conventions.AuthorizeFolder("/MorseDefaultConversions");
});
builder.Services.AddDbContext<MorseCodeApp2Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MorseCodeApp2Context") ?? throw new InvalidOperationException("Connection string 'MorseCodeApp2Context' not found.")));

builder.Services.AddDbContext<MorseCodeApp2IdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MorseCodeApp2Context") ?? throw new InvalidOperationException("Connection string 'MorseCodeApp2Context' not found.")));
builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<MorseCodeApp2IdentityContext>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
