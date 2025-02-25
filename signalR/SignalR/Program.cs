using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.ResponseCompression;
using Radzen;
using SignalR.Data;
using SignalR.Services;
using SignalR.Services.Admin;
using AutoMapper;
using SignalR.Mapper;
using SignalR.Hubs;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
// builder.Services.AddSingleton<WeatherForecastService>();

// register dependencies
builder.Services.AddHttpClient();

// inject signalR to IserviceCollection
builder.Services.AddSignalR(e =>
{
    e.MaximumReceiveMessageSize = 102400000;
});
builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        ["application/octet-stream"]);
});



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

// app.UseResponseCompression();

app.UseRouting();



app.MapHub<ProductHub>("/product-hub"); // hub listen to specific path
app.MapBlazorHub(options =>
{
    options.TransportMaxBufferSize = 10 * 1024 * 1024;
});  

app.MapFallbackToPage("/_Host");

app.Run();
