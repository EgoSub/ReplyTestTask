using OpenQA.Selenium;
using PageObject.CustomElements;

namespace PageObject.Pages
{
    public class ContactPage : HomePage
    {
        public ContactPage()
        {
            Wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            Wait.Until(x => MainTitle.Displayed);
        }
        public IWebElement MainTitle => Driver.FindElement(By.Id("main-title"));

        public IWebElement CreateContact()
        {
            var wait = Wait;
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            wait.Until(dr => Driver.FindElement(By.XPath("//div[@class = 'card-header panel-subheader listview-header']//button[@name = 'SubPanel_create']")).Enabled);
            return Driver.FindElement(By.XPath("//div[@class = 'card-header panel-subheader listview-header']//button[@name = 'SubPanel_create']"));
        }

        public IWebElement FirstName => Driver.FindElement(By.Id("DetailFormfirst_name-input"));
        public IWebElement LastName => Driver.FindElement(By.Id("DetailFormlast_name-input"));
        public Selector Category => new(Driver.FindElement(By.Id("DetailFormcategories-input")));
        public IWebElement CategoryOptions(string option) => Driver.FindElement(By.Id("DetailFormcategories-input-search-list")).FindElement(By.LinkText(option));
        public Selector BusinessRole => new(Driver.FindElement(By.Id("DetailFormbusiness_role-input")));
        public IWebElement Save => Driver.FindElement(By.Id("DetailForm_save"));
    }
}
