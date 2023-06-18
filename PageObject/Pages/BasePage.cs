using Core;
using InVentry.TestAutomation.UI.Core.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace PageObject.Pages
{
    public class BasePage
    {
        public IWebDriver Driver => ThreadDriverManager.GetWebDriver();
        public WebDriverWait WaitUntil => new(Driver, TimeSpan.FromSeconds(ConfigManager.Wait));
        public Actions Action => new(Driver);
        public void RefreshPage() => Driver.Navigate().Refresh();
        public virtual void GoTo() => Driver.Navigate().GoToUrl(ConfigManager.BaseUrl);

    }
}
