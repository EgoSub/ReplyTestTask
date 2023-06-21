using OpenQA.Selenium;

namespace InVentry.TestAutomation.UI.Core.Selenium
{
    public static class ThreadDriverManager
    {
        private static readonly ThreadLocal<IWebDriver> LocalWebDriver = new(true);
        private static Dictionary<string, string> _cookies;

        public static IWebDriver GetWebDriver()
        {
            if (LocalWebDriver.Value != null) return LocalWebDriver.Value;

            LocalWebDriver.Value = DriverBuilder.GetDriver();
            if (_cookies != null)
            {
                LocalWebDriver.Value.Manage().Cookies.DeleteAllCookies();
                SetCookies(_cookies);
            }
            return LocalWebDriver.Value;
        }

        public static void SetGlobalCookies(Dictionary<string, string> cookies)
        {
            _cookies = cookies;
        }

        public static void SetCookies(Dictionary<string, string> cookies)
        {
            var driver = GetWebDriver();
            foreach (var (cookieKey, cookieValue) in cookies)
                driver.Manage().Cookies.AddCookie(new Cookie(cookieKey, cookieValue));
        }

        public static void CloseCurrentBrowser()
        {
            LocalWebDriver.Value?.Quit();
            LocalWebDriver.Value = null;
        }

        public static void CloseAllBrowsers()
        {
            LocalWebDriver.Values.ToList().ForEach(wd => wd?.Quit());
        }
    }
}