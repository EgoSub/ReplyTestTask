using Core;
using Core.Extensions;
using InVentry.TestAutomation.UI.Core.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;

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

        public IWebElement FindElement(By by)
        {
            LoadingPopup.WaitUntil(el => !el.Displayed);
            return Driver.FindElement(by);
        }
        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            LoadingPopup.WaitUntil(el => !el.Displayed);
            return Driver.FindElements(by);
        }
    }
}
