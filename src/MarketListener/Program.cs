using MarketListener.Api.Endpoints;
using MarketListener.Application;
using MarketListener.Persistence.Ef;
using MarketListener.Persistence.Ef.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApplicationServices(builder.Configuration)
    .AddPersistenceEfServices(builder.Configuration);

var connectionString = builder.Configuration.GetConnectionString("BaseConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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

//app.MapGet("/", () => "Hello World!");

app.MapAnswerEndpoints();

app.MapQuestionEndpoints();

app.MapAuthenticationEndpoints();

app.Run();
