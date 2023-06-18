# ReplyTestTask

QA Automation Engineer test task Please, create automated tests for portal https://demo.1crmcloud.com according to the requirements and cases below. Requirements (must have):  Use C# + SpecFlow (https://docs.specflow.org/projects/getting-started/en/latest/index.html)

Selenium WebDriver  Please, create a small framework for this task. What we expect to have: o Use page object pattern o Configuration via files o Effective reuse of the code  Follow coding best practices Optional:  Connect any HTML reporter  Login using API (via hook) Test cases
Scenario 1 – Create contact:
Login
Navigate to “Sales & Marketing” -> “Contacts”
Create new contact (Enter at least first name, last name, role and 2 categories: Customers and Suppliers)
Open created contact and check that its data matches entered on the previous step

Scenario 2 – Run report:
Login
Navigate to “Reports & Settings” -> “Reports”
Find “Project Profitability” report
Run report and verify that some results were returned

Scenario 3 – Remove events from activity log:
Login
Navigate to “Reports & Settings” -> “Activity log”
Select first 3 items in the table
Click “Actions” -> “Delete”
Verify that items were deleted
