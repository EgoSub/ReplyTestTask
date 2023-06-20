using Core;
using Core.Extensions;
using Core.Generators;
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
            var homePage = new HomePage();
            homePage.Header.NavigationMenu(mainTab).Click();
            homePage.Header.SecondItem(nestedTab).Click();
        }


        [When(@"create new contact with categories:")]
        public void WhenCreateNewContactWithCategories(Table table)
        {
            var rows = table.Rows;
            var contactPage = new ContactPage();
            var contact = new ContactGenerator().Generate();
            contactPage.LoadingPopup.WaitUntil(el => !el.Displayed);
            contactPage.CreateContact().WaitUntil(el => !contactPage.LoadingPopup.Displayed).Click();
            contactPage.FirstName.SendKeys(contact.FirstName);
            contactPage.LastName.SendKeys(contact.LastName);
            foreach (var row in rows)
            {
                contactPage.LoadingPopup.WaitUntil(el => !el.Displayed);
                contactPage.Category.ChooseOption(row.Values.FirstOrDefault());
            }
            contactPage.LoadingPopup.WaitUntil(el => !el.Displayed);
            contactPage.BusinessRole.ChooseOption(contact.BusinessRole.ToString());
            contactPage.Save.Click();
        }


        [When(@"open created contact")]
        public void WhenOpenCreatedContact()
        {

        }

        [Then(@"check that its data matches")]
        public void ThenCheckThatItsDataMatches()
        {
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
            false.Should().Be(true);
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
