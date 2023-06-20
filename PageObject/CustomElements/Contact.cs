using OpenQA.Selenium;

namespace PageObject.CustomElements
{
    public class Contact
    {
        private IWebElement element;

        public Contact(IWebElement element)
        {
            this.element = element;
        }

        public IWebElement Name => element.FindElement(By.ClassName("listViewNameLink"));
        public string AccountName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Category { get; set; }
        public string User { get; set; }

    }
}