using Microsoft.AspNetCore.Blazor.Browser.Http;
using Microsoft.AspNetCore.Blazor.Hosting;

namespace Forms.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BrowserHttpMessageHandler.DefaultCredentials = FetchCredentialsOption.Include;
            CreateHostBuilder(args).Build().Run();
        }

        public static IWebAssemblyHostBuilder CreateHostBuilder(string[] args) =>
            BlazorWebAssemblyHost.CreateDefaultBuilder()
                .UseBlazorStartup<Startup>();
    }
}
