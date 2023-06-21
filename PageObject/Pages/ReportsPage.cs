using OpenQA.Selenium;
using PageObject.CustomElements.ListElements;

namespace PageObject.Pages
{
    public class ReportsPage : HomePage
    {
        public ItemsList<Report> ReportsList => DefaultItemsList<Report>();
        public IWebElement RunReport => FindElement(By.XPath("//span[text() = 'Run Report']/.."));
    }
}
