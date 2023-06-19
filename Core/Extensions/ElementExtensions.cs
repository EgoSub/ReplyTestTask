
using InVentry.TestAutomation.UI.Core.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System.Linq.Expressions;

namespace Core.Extensions
{
    public static class ElementExtensions
    {
        public static void ClickAfterAjax(this IWebElement element)
        {
            var driver = ThreadDriverManager.GetWebDriver();
            element.WaitUntil(el => driver.ExecuteJavaScript<bool>("return jQuery.active == 0") == true).Click();
        }

        public static IWebElement WaitUntil(this IWebElement element, Expression<Predicate<IWebElement>> condition)
        {
            var driver = ThreadDriverManager.GetWebDriver();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(ConfigManager.Wait));
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException),
                typeof(NoSuchElementException), typeof(InvalidElementStateException), typeof(NullReferenceException), typeof(ArgumentNullException));
            wait.Until(driver => condition.Compile().Invoke(element));
            return element;
        }
    }
}
