using Core;
using Core.Selenium.BrowserFactory;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

public static class DriverBuilder
{
    public static IWebDriver GetDriver()
    {
        IWebDriver driver;
        driver = ConfigManager.Browser switch
        {
            BrowserType.Chrome => InitChrome(ConfigManager.BrowserOptions),
            BrowserType.Firefox => InitFireFox(ConfigManager.BrowserOptions),
            BrowserType.Edge => InitEdge(ConfigManager.BrowserOptions),
            _ => throw new Exception($"Driver type not found in configuration. Actual browser type: {ConfigManager.Browser}")
        };
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ConfigManager.Wait);
        driver.Navigate().GoToUrl(ConfigManager.BaseUrl);
        return driver;
    }

    private static IWebDriver InitChrome(string? options)
    {
        new DriverManager().SetUpDriver(new ChromeConfig(), "MatchingBrowser");
        var chromeOptions = new ChromeOptions();
        chromeOptions.AddArguments(options);
        return new ChromeDriver(chromeOptions);
    }

    private static IWebDriver InitFireFox(string? options)
    {
        new DriverManager().SetUpDriver(new FirefoxConfig(), "MatchingBrowser");
        var fireFoxOptions = new FirefoxOptions();
        fireFoxOptions.AddArguments(options);
        return new FirefoxDriver(fireFoxOptions);
    }

    private static IWebDriver InitEdge(string? options)
    {
        new DriverManager().SetUpDriver(new EdgeConfig(), "MatchingBrowser");
        var edgeOptions = new EdgeOptions();
        edgeOptions.AddArguments(options);
        return new EdgeDriver(edgeOptions);
    }
}
