Feature: CheckBoxDemo
	To Verify the check box Demo Page

Background: 
	Given I Navigate to Demo Website
	And I Select Checkbox Demo from Input Forms
	Then I see Checkbox Demo Page displayed

@Smoke
Scenario: Test Single Checkbox Field	
	Given I select checkbox "Click on this check box"
	Then I see the Success message as "Success - Check box is checked" for Single Checkbox

@Regression
Scenario: Test CheckAll in Multi-Checkbox 	
	Given I Click "Check All" Button
	Then I see Button Text as "Uncheck All"
	Given I Click "Uncheck All" Button
	Then I see Button Text as "Check All"

@Regression
Scenario: Test individual check boxes in Multi-Checkbox
	Given I check checkbox "Option1"
	And I check checkbox "Option2"
	And I check checkbox "Option3"
	And I check checkbox "Option4"
	Then I see Button Text as "Uncheck All"

@Regression
Scenario: Test individual Uncheck boxes in Multi-Checkbox
	Given I uncheck checkbox "Option1"
	Then I see Button Text as "Check All"
	
