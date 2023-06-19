using Core.ApiClient;
using InVentry.TestAutomation.UI.Core.Selenium;
using PageObject.Pages;
using SpecFlowBDDAutomationFramework.Utility;

namespace SpecFlowTests.Hooks
{
    [Binding]
    public class TestHooks
    {
        [BeforeTestRun()]
        public static void BeforeTestRun()
        {
            ExtentReport.ExtentReportInit();
        }

        [BeforeScenario("@apiLogin")]
        public void ApiLogin()
        {
            var loginResponse = new ApiClient().Login();
            ThreadDriverManager.SetCookies(new Dictionary<string, string>() { { loginResponse.session_name, loginResponse.json_session_id } });
            new BasePage().ReOpen();
        }

        [BeforeScenario()]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            ExtentReport.AddScenario(scenarioContext.ScenarioInfo.Title);
        }

        [BeforeFeature()]
        public static void ApiLogin(FeatureContext featureContext)
        {
            ExtentReport.AddTest(featureContext.FeatureInfo.Title);
        }

        [AfterStep()]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            ExtentReport.AddScenario(scenarioContext.StepContext.StepInfo.Text, scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString(), scenarioContext.TestError);
        }

        [AfterScenario]
        public void CloseCurrentBrowser()
        {
            ThreadDriverManager.CloseCurrentBrowser();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            ExtentReport.ExtentReportTearDown();
            ThreadDriverManager.CloseAllBrowsers();
        }
    }
}
