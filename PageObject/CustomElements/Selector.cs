using InVentry.TestAutomation.UI.Core.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;


namespace PageObject.CustomElements
{
    public class Selector
    {
        private IWebElement element;
        public Selector(IWebElement ddElement)
        {
            element = ddElement;
        }

        public void ChooseOption(string option)
        {
            var dr = ThreadDriverManager.GetWebDriver();
            var elementId = element.GetAttribute("id");
            element.Click();
            var optElement = dr.FindElement(By.XPath($"//div[contains(@id, '{elementId}')]//div[contains(text(), '{option}')]"));
            new Actions(dr)
                .MoveToElement(optElement)
                .Click(optElement)
                .Perform();
            //TODO: Unfortunately nothing works better then sleep here
            Thread.Sleep(1000);
        }
    }
}
