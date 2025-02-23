using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using SignalR.Data;
using SignalR.Services;
using SignalR.Services.Admin;
using AutoMapper;
using SignalR.Mapper;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
// builder.Services.AddSingleton<WeatherForecastService>();

// register dependencies
builder.Services.AddHttpClient();
builder.Services.AddSignalR();



//Thư viện auto mapper
var mapperConfiguration = new MapperConfiguration(cfg =>
{
    // configuration.AddProfile(new MappingProfile());
    cfg.AddProfile<MappingProfile>();
});
var mapper = mapperConfiguration.CreateMapper();
builder.Services.AddSingleton(mapper);

// Radzen Component


builder.Services.AddSingleton<ProductService>();
builder.Services.AddSingleton<ProductCategoryService>();

builder.Services.AddRadzenComponents();



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

app.MapBlazorHub();

app.MapFallbackToPage("/_Host");

app.Run();
