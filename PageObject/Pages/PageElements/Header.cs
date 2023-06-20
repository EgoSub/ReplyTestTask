using OpenQA.Selenium;

namespace PageObject.Pages.PageElements
{

    public class Header : BasePage
    {
        readonly IWebElement _element;

        public Header(IWebElement element)
        {
            _element = element;
        }
        public IWebElement NavigationMenu(string item) => _element.FindElement(By.XPath($".//a/div[contains(text(), '{item}')]"));
        public IWebElement SecondMenuTab => Wait.Until(dr => dr.FindElement(By.ClassName("tab-nav-sub")));
        public IWebElement SecondItem(string item) => SecondMenuTab.FindElement(By.XPath($"//a[@class = 'menu-tab-sub-list' and text() = ' {item}']"));
        public void NavigationMenu(string firstItem, string secondItem) => Action.MoveToElement(NavigationMenu(firstItem)).Click(SecondItem(secondItem)).Perform();
    }
}
