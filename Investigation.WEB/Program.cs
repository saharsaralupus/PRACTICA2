using CurrieTechnologies.Razor.SweetAlert2;
using Investigation.WEB;
using Investigation.WEB.Repositories;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7000") });

builder.Services.AddSweetAlert2();

builder.Services.AddScoped<IRepository, Repository>();
await builder.Build().RunAsync();
