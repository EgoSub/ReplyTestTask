using Core;
using Core.Extensions;
using Core.Generators;
using Core.Models;
using FluentAssertions.Execution;
using OpenQA.Selenium;
using PageObject.Pages;

namespace SpecFlowTests.StepDefinitions
{
    [Binding]
    public class CrmCloudStepDefinitions
    {
        public ScenarioContext ScenarioContext { get; }

        public CrmCloudStepDefinitions(ScenarioContext scenarioContext)
        {
            ScenarioContext = scenarioContext;
        }

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
            homePage.Header.SecondItem(nestedTab).ClickWithJs();
        }


        [When(@"create new contact with categories:")]
        public void WhenCreateNewContactWithCategories(Table table)
        {
            var rows = table.Rows;
            var contactPage = new ContactsPage();
            var contact = new ContactGenerator().Generate();
            contactPage.CreateContact().Click();
            contactPage.FirstName.SendKeys(contact.FirstName);
            contactPage.LastName.SendKeys(contact.LastName);
            contact.Categories = new();
            foreach (var row in rows)
            {
                contact.Categories.Add(row.Values.First());
                contactPage.Category.ChooseOption(row.Values.First());
            }
            ScenarioContext.Add("contact", contact);
            contactPage.BusinessRole.ChooseOption(contact.BusinessRole.ToString());
            contactPage.Save.Click();
        }


        [When(@"open created contact")]
        public void WhenOpenCreatedContact()
        {
            var contact = ScenarioContext.Get<Contact>("contact");
            var contactPage = new ContactsPage();
            contactPage.Contacts.Click();
            contactPage.Filter.SendKeys($"{contact.FirstName} {contact.LastName}");
            contactPage.Filter.SendKeys(Keys.Enter);
            contactPage.ContactsList.FirstOrDefault(el => el.Name.Text.Contains($"{contact.FirstName} {contact.LastName}")).Name.Click();
        }

        [Then(@"check that its data matches")]
        public void ThenCheckThatItsDataMatches()
        {
            var contact = ScenarioContext.Get<Contact>("contact");
            var contactPage = new ContactsPage();
            using (new AssertionScope())
            {
                contactPage.ContactDetailForm.FullName.Text.Should().Contain($"{contact.FirstName} {contact.LastName}");
                contactPage.ContactDetailForm.BusinessRole.Text.Should().Be(contact.BusinessRole.ToString());
                foreach (var cat in contact.Categories)
                {
                    contactPage.ContactDetailForm.Categories.Text.Should().Contain(cat);
                }
            }
        }

        [Given(@"navigate to �Reports & Settings�")]
        public void GivenNavigateToReportsSettings()
        {
            throw new PendingStepException();
        }

        [Given(@"navigate to �Reports�")]
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

        [Given(@"navigate to �Activity log�")]
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
