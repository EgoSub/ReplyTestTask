using Core.ApiClient;
using InVentry.TestAutomation.UI.Core.Selenium;
using PageObject.Pages;

namespace SpecFlowTests.Hooks
{
    [Binding]
    public class TestHooks
    {

        [BeforeScenario("@apiLogin")]
        public void Login()
        {
            var loginResponse = new ApiClient().Login();
            ThreadDriverManager.SetCookies(new Dictionary<string, string>() { { loginResponse.session_name, loginResponse.json_session_id } });
            new BasePage().GoTo();
        }

        [AfterScenario]
        public void CloseCurrentBrowser()
        {
            ThreadDriverManager.CloseCurrentBrowser();
        }

        [AfterTestRun]
        public static void CloseAllBrowsers()
        {
            ThreadDriverManager.CloseAllBrowsers();
        }
    }
}
