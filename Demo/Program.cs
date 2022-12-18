using Demo;
using Demo.Pages;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PeterLeslieMorris.Blazor.Validation;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


builder.Services.AddFormValidation(config =>
    config.AddFluentValidation(typeof(InputFieldDemo.FormModel).Assembly));

await builder.Build().RunAsync();
