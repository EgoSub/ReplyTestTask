using OpenQA.Selenium;

namespace PageObject.Pages.PageElements
{
    public class ContactDetailForm : BasePage
    {
        readonly IWebElement _element;
        public ContactDetailForm(IWebElement element)
        {
            _element = element;
        }
        public IWebElement FullName => _element.FindElement(By.XPath("//div[@id = '_form_header']//h3"));
        public IWebElement Categories => _element.FindElement(By.XPath("//ul[@class = 'summary-list']//p/.."));
        public IWebElement BusinessRole => _element.FindElement(By.XPath("//div[@id = 'main-0']//p[text() = 'Business Role']/../div"));
    }
}
