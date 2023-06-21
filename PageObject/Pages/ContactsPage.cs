using OpenQA.Selenium;
using PageObject.CustomElements;
using PageObject.CustomElements.ListElements;
using PageObject.Pages.PageElements;

namespace PageObject.Pages
{
    public class ContactsPage : HomePage
    {
        public IWebElement MainTitle => Driver.FindElement(By.Id("main-title"));
        public IWebElement CreateContact()
        {
            Wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            Wait.Until(dr => Driver.FindElement(By.XPath("//div[@class = 'card-header panel-subheader listview-header']//button[@name = 'SubPanel_create']")).Enabled);
            return FindElement(By.XPath("//div[@class = 'card-header panel-subheader listview-header']//button[@name = 'SubPanel_create']"));
        }

        public IWebElement Filter => FindElement(By.Id("filter_text"));
        public IWebElement Contacts => FindElement(By.XPath("//div[@id = 'left-sidebar']//div[contains(@class, 'module-Contacts')]"));
        public List<Contact> ContactsList => FindElements(By.XPath("//table[@class = 'listView']//tbody/tr")).Select(el => new Contact(el)).ToList();
        public IWebElement FirstName => Driver.FindElement(By.Id("DetailFormfirst_name-input"));
        public IWebElement LastName => Driver.FindElement(By.Id("DetailFormlast_name-input"));
        public Selector Category => new(FindElement(By.Id("DetailFormcategories-input")));
        public IWebElement CategoryOptions(string option) => Driver.FindElement(By.Id("DetailFormcategories-input-search-list")).FindElement(By.LinkText(option));
        public Selector BusinessRole => new(FindElement(By.Id("DetailFormbusiness_role-input")));
        public IWebElement Save => Driver.FindElement(By.Id("DetailForm_save"));
        public ContactDetailForm ContactDetailForm => new(FindElement(By.XPath("//form[@id = 'DetailForm']")));
    }
}
