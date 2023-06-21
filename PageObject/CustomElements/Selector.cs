using InVentry.TestAutomation.UI.Core.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;


namespace PageObject.CustomElements
{
    public class Selector : CustomElement
    {
        public Selector(IWebElement element) : base(element)
        {
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
        }
        public void ChooseOptions(List<string> options)
        {
            foreach (var opt in options)
            {
                ChooseOption(opt);
                ////TODO: Seems like dd animation time. I tried hard but to get rid of it need more time.
                Thread.Sleep(500);
            }
        }
    }
}
