using Core;
using Core.Extensions;
using Core.Generators;
using FluentAssertions.Execution;
using OpenQA.Selenium;
using PageObject.CustomElements;
using PageObject.Pages;
using System.Globalization;

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
            homePage.LoadingPopup.WaitUntil(el => !el.Displayed);
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
            var options = rows.Select(el => el.Values.First()).ToList();
            contact.Categories = contact.Categories;
            contactPage.Category.ChooseOptions(options);
            ScenarioContext.Add("contact", contact);
            contactPage.BusinessRole.ChooseOption(contact.BusinessRole.ToString());
            contactPage.Save.Click();
        }


        [When(@"open created contact")]
        public void WhenOpenCreatedContact()
        {
            var contact = ScenarioContext.Get<Core.Models.Contact>("contact");
            var contactPage = new ContactsPage();
            contactPage.Contacts.Click();
            contactPage.Filter.SendKeys($"{contact.FirstName} {contact.LastName}");
            contactPage.Filter.SendKeys(Keys.Enter);
            contactPage.ContactsList.FirstOrDefault(el => el.Name.Text.Contains($"{contact.FirstName} {contact.LastName}")).Name.Click();
        }

        [Then(@"check that its data matches")]
        public void ThenCheckThatItsDataMatches()
        {
            var contact = ScenarioContext.Get<Core.Models.Contact>("contact");
            var contactPage = new ContactsPage();
            using (new AssertionScope())
            {
                contactPage.ContactDetailForm.FullName.Text.Should().Contain($"{contact.FirstName} {contact.LastName}", "Contact full name should be matched");
                contactPage.ContactDetailForm.BusinessRole.Text.Should().Be(contact.BusinessRole.ToString(), "BusinessRole should be matched");
                foreach (var cat in contact.Categories)
                {
                    contactPage.ContactDetailForm.Categories.Text.Should().Contain(cat, "Categories should be matched");
                }
            }
        }

        [Given(@"find ""([^""]*)"" report")]
        public void GivenFindReport(string reportName)
        {
            var reportsPage = new ReportsPage();
            reportsPage.ReportsList.Filter.SendKeys(reportName);
            reportsPage.ReportsList.Filter.SendKeys(Keys.Enter);
            var items = reportsPage.ReportsList.Items;
            items.FirstOrDefault(el => el.Name.Text.Contains($"{reportName}")).Name.Click();
        }

        [When(@"Run report")]
        public void WhenRunReport()
        {
            var reportsPage = new ReportsPage();
            reportsPage.RunReport.Click();
        }


        [Then(@"verify that some results were returned")]
        public void ThenVerifyThatSomeResultsWereReturned()
        {
            var reportsPage = new ReportsPage();
            var itemList = reportsPage.DefaultItemsList<CustomElement>();
            using (new AssertionScope())
            {
                itemList.Items.Count.Should().NotBe(0, "Project Profitability items should be present");
                int.Parse(itemList.SelectedOf.Text).Should().BeGreaterThan(0, "'Selected of' should have count of all items");
            }
        }

        [When(@"select first (.*) items in the table")]
        public void WhenSelectFirstItemsInTheTable(int countOfItems)
        {
            var activityLogPage = new ActivityLogPage();
            ScenarioContext.Add($"activityLogs", new List<string>());
            ScenarioContext.Add($"selectOfCount", int.Parse(activityLogPage.ActivityLogList.SelectedOf.Text, NumberStyles.AllowThousands));
            var logList = activityLogPage.ActivityLogList;
            for (int i = 0; i < countOfItems; i++)
            {
                var item = logList.Items[i];
                ScenarioContext.Get<List<string>>("activityLogs").Add(item.Name.Text);
                item.CheckBox.Click();
            }
        }

        [When(@"Make ""([^""]*)"" action")]
        public void WhenMakeAction(string actionOption)
        {
            var activityLogPage = new ActivityLogPage();
            activityLogPage.ActivityLogList.Action.ChooseOption(actionOption);
            activityLogPage.Allert.Accept();
        }

        [Then(@"verify that items were deleted")]
        public void ThenVerifyThatItemsWereDeleted()
        {
            var activityLogPage = new ActivityLogPage();
            var itemOnPage = activityLogPage.ActivityLogList.Items.Select(el => el.Name.Text).ToList();
            var oldCount = ScenarioContext.Get<int>($"selectOfCount");
            var deletedItems = ScenarioContext.Get<List<string>>("activityLogs");

            using (new AssertionScope())
            {
                itemOnPage.Should().NotContain(deletedItems, "Deleted Items should not be on the list");
                int.Parse(activityLogPage.ActivityLogList.SelectedOf.Text, NumberStyles.AllowThousands).Should().Be(oldCount - deletedItems.Count, "Current count of items should be less the before item were deleted");
            }
        }
    }
}
