using OpenQA.Selenium;
using PageObject.Pages.PageElements;

namespace PageObject.Pages
{
    public class HomePage : BasePage
    {
        public Header Header => new(Driver.FindElement(By.ClassName("nav-wrap")));
    }
}
