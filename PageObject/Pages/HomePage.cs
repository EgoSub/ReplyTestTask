using OpenQA.Selenium;
using PageObject.Pages.PageElements;

namespace PageObject.Pages
{
    public class HomePage : BasePage
    {
        public Header Header => new(FindElement(By.ClassName("nav-wrap")));
    }
}
