using Core;
using InVentry.TestAutomation.UI.Core.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace PageObject.Pages
{
    public class BasePage
    {
        public IWebElement LoadingPopup => Driver.FindElement(By.Id("ajaxStatusDiv"));
        public IWebDriver Driver => ThreadDriverManager.GetWebDriver();
        public WebDriverWait Wait => new(Driver, TimeSpan.FromSeconds(ConfigManager.Wait));
        public Actions Action => new(Driver);
        public void RefreshPage() => Driver.Navigate().Refresh();
        public virtual void ReOpen() => Driver.Navigate().GoToUrl(ConfigManager.BaseUrl);
    }
}
