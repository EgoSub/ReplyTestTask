Feature: Crmcloud

@apiLogin
Scenario: Create contact
	Given navigate to "Sales & Marketing" => "Contacts"
	When create new contact with categories:
	| Categories |
	| Customers  |
	| Suppliers  |
	And open created contact
	Then check that its data matches

@apiLogin
Scenario: Run report
	Given navigate to "Reports & Settings" => "Reports"
	And find "Project Profitability" report
	When Run report
	Then verify that some results were returned

@apiLogin
Scenario: Remove events from activity log
	Given navigate to "Reports & Settings" => "Activity Log"
	When select first 3 items in the table
	And Make "delete" action
	Then verify that items were deleted