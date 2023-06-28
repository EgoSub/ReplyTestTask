using OpenQA.Selenium;

namespace PageObject.CustomElements
{
    public class CustomElement
    {
        protected IWebElement element;

        public CustomElement(IWebElement element)
        {
            this.element = element;
        }
    }
}
