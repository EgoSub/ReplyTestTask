using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;

namespace SpecFlowBDDAutomationFramework.Utility
{
    public class ExtentReport
    {
        public static ExtentReports _extentReports;
        public static ExtentTest _feature;
        private static ExtentTest _scenario;

        private static string dir = AppDomain.CurrentDomain.BaseDirectory;
        private static string testResultPath = dir.Replace("bin\\Debug\\net6.0", "TestResults");


        public static void ExtentReportInit()
        {
            var htmlReporter = new ExtentHtmlReporter(testResultPath);
            htmlReporter.Config.ReportName = "Automation Status Report";
            htmlReporter.Config.DocumentTitle = "Automation Status Report";
            htmlReporter.Config.Theme = Theme.Dark;
            htmlReporter.Start();
            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(htmlReporter);
        }
        public static void AddScenario(string title)
        {
            _scenario = _feature.CreateNode<Scenario>(title);
        }

        public static void AddScenario(string stepName, string stepType, Exception ex)
        {
            var keyword = stepType switch
            {
                "Given" => typeof(Given),
                "When" => typeof(When),
                "Then" => typeof(Then),
                _ => throw new NotImplementedException(),
            };
            var gK = new GherkinKeyword(keyword.Name);
            if (ex == null)
            {
                _scenario.CreateNode(gK, stepName);
            }
            else
            {
                _scenario.CreateNode(gK, stepName).Fail(ex);
            }
        }

        public static void AddTest(string title)
        {
            _feature = _extentReports.CreateTest<Feature>(title);
        }

        public static void ExtentReportTearDown()
        {
            _extentReports.Flush();
        }

    }
}