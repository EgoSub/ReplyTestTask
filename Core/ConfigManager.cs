using Core.Selenium.BrowserFactory;
using Microsoft.Extensions.Configuration;

namespace Core
{
    public static class ConfigManager
    {
        public static IConfigurationRoot Configuration => new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddJsonFile("appsettings.local.json", true)
            .Build();
        private static readonly IConfigurationSection SeleniumConfiguration = Configuration.GetSection("SeleniumConfiguration");
        private static readonly IConfigurationSection UserCredentials = Configuration.GetSection("UserCredentials");
        public static string? BaseUrl => Configuration["BaseUrl"];
        public static BrowserType Browser =>
            (BrowserType)Enum.Parse(typeof(BrowserType), SeleniumConfiguration["Browser"]);
        public static string? BrowserOptions => SeleniumConfiguration["Options"];
        public static double Wait => double.Parse(SeleniumConfiguration["Wait"]);
        public static string? Username => UserCredentials["Username"];
        public static string? Password => UserCredentials["Password"];
    }
}
