
using InVentry.TestAutomation.UI.Core.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System.Linq.Expressions;

namespace Core.Extensions
{
    public static class ElementExtensions
    {
        private static IWebDriver driver => ThreadDriverManager.GetWebDriver();
        public static void ClickAfterAjax(this IWebElement element)
        {
            element.WaitUntil(el => driver.ExecuteJavaScript<bool>("return jQuery.active == 0") == true).Click();
        }

        public static IWebElement WaitUntil(this IWebElement element, Expression<Predicate<IWebElement>> condition)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(ConfigManager.Wait));
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException),
                typeof(NoSuchElementException), typeof(InvalidElementStateException), typeof(NullReferenceException), typeof(ArgumentNullException));
            wait.Until(driver => condition.Compile().Invoke(element));
            return element;
        }

        public static void ClickWithJs(this IWebElement element)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript($"arguments[0].style.border='1px solid green'", element);

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", element);
            Thread.Sleep(10000);
        }

    }
}
