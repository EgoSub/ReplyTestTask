using Core.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;


namespace PageObject.CustomElements
{
    public class Selector : CustomElement
    {
        public Selector(IWebElement element) : base(element)
        {
        }

        private IWebDriver Driver = ThreadDriverManager.GetWebDriver();
        private string ElementId => element.GetAttribute("id");
        private IWebElement OptionElement(string option) => Driver.FindElement(By.XPath($"//div[contains(@id, '{ElementId}')]//div[contains(text(), '{option}')]"));
        public void ChooseOption(string option)
        {
            element.Click();
            new Actions(Driver)
                .MoveToElement(OptionElement(option))
                .Click(OptionElement(option))
                .Perform();
        }
        public void ChooseOptions(List<string> options)
        {
            foreach (var opt in options)
            {
                ChooseOption(opt);
                ////TODO: Seems like dd animation time. I tried hard but to get rid of this need much more time.
                Thread.Sleep(500);
            }
        }
    }
}
