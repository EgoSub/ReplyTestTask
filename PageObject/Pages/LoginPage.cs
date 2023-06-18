using OpenQA.Selenium;

namespace PageObject.Pages
{
    public class LoginPage : BasePage
    {
        public IWebElement Login => Driver.FindElement(By.Id("login_user"));
        public IWebElement Password => Driver.FindElement(By.Id("login_pass"));
        public IWebElement LoginButton => Driver.FindElement(By.Id("login_button"));
    }
}
