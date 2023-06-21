using OpenQA.Selenium;

namespace PageObject.CustomElements.ListElements
{
    public class Contact : CustomElement
    {
        public Contact(IWebElement element) : base(element)
        {
        }
        public IWebElement Name => element.FindElement(By.ClassName("listViewNameLink"));
        public string AccountName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Category { get; set; }
        public string User { get; set; }
    }
}