using OpenQA.Selenium;

namespace PageObject.CustomElements.ListElements
{
    public class ActivityLog : CustomElement
    {
        public ActivityLog(IWebElement element) : base(element)
        {
        }
        public IWebElement CheckBox => element.FindElement(By.ClassName("checkbox"));
        public IWebElement Name => element.FindElement(By.XPath("//span[@class = 'detailLink']/a"));
        public IWebElement CreatedBy => element.FindElement(By.XPath("//span[not(@class = 'detailLink')]/a"));
        public IWebElement Icon => element.FindElement(By.XPath("//div[@title]"));
        public string Type => Icon.GetAttribute("title");
    }
}
