using OpenQA.Selenium;

namespace PageObject.CustomElements
{

    public class ItemsList<T> : CustomElement where T : CustomElement
    {
        public ItemsList(IWebElement element) : base(element)
        {
        }
        public List<T> Items => element.FindElements(By.XPath(".//table[@class = 'listView']//tbody/tr")).Select(el => (T)Activator.CreateInstance(typeof(T), el)).ToList();
        public IWebElement Filter => element.FindElement(By.Id("filter_text"));
        public IWebElement Create => element.FindElement(By.XPath("//button[@name = 'SubPanel_create']"));
        public IWebElement SelectedOf => element.FindElement(By.XPath("//div[contains(@class, 'header')]//div[contains(text(), 'Selected:')]//span[not(@id)]"));

    }
}
