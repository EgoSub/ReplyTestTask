using Core;
using PageObject.Pages;

namespace SpecFlowTests.StepDefinitions
{
    [Binding]
    public class CrmcloudStepDefinitions
    {
        [Given(@"login")]
        public void GivenLogin()
        {
            var loginPage = new LoginPage();
            loginPage.Login.SendKeys(ConfigManager.Username);
            loginPage.Password.SendKeys(ConfigManager.Password);
            loginPage.LoginButton.Click();
        }

        [Given(@"navigate to ""([^""]*)"" => ""([^""]*)""")]
        public void GivenNavigateTo(string mainTab, string nestedTab)
        {
            Thread.Sleep(10000);

            var homePage = new HomePage();
            homePage.Header.NavigationMenu(mainTab).Click();
            homePage.Header.SecondItem(nestedTab).Click();
            Thread.Sleep(10000);
        }


        [When(@"create new contact with categories:")]
        public void WhenCreateNewContactWithCategories(Table table)
        {
            throw new PendingStepException();
        }


        [When(@"open created contact")]
        public void WhenOpenCreatedContact()
        {
            throw new PendingStepException();
        }

        [Then(@"check that its data matches")]
        public void ThenCheckThatItsDataMatches()
        {
            throw new PendingStepException();
        }

        [Given(@"navigate to “Reports & Settings”")]
        public void GivenNavigateToReportsSettings()
        {
            throw new PendingStepException();
        }

        [Given(@"navigate to “Reports”")]
        public void GivenNavigateToReports()
        {
            throw new PendingStepException();
        }

        [Given(@"find ""([^""]*)"" report")]
        public void GivenFindReport(string reportName)
        {
            throw new PendingStepException();
        }


        [When(@"Run report")]
        public void WhenRunReport()
        {
            throw new PendingStepException();
        }

        [Then(@"verify that some results were returned")]
        public void ThenVerifyThatSomeResultsWereReturned()
        {
            throw new PendingStepException();
        }

        [Given(@"navigate to “Activity log”")]
        public void GivenNavigateToActivityLog()
        {
            throw new PendingStepException();
        }

        [When(@"select first (.*) items in the table")]
        public void WhenSelectFirstItemsInTheTable(int p0)
        {
            throw new PendingStepException();
        }

        [When(@"Make ""([^""]*)"" action")]
        public void WhenMakeAction(string delete)
        {
            throw new PendingStepException();
        }


        [Then(@"verify that items were deleted")]
        public void ThenVerifyThatItemsWereDeleted()
        {
            throw new PendingStepException();
        }
    }
}
