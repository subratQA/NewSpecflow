Feature: SimpleFormDemo
	This feature tests the simple form controls of Input Forms Main Page


Background: 
	Given I Navigate to Demo Website
	And I Select "Simple Form Demo" from Input Forms
	Then I see Input Form Page displayed

@Smoke
Scenario: Test Single Input Field	
	Given I Enter "Sample Text" in Enter Message field
	And I click on Button Show Message
	Then I see the Output message as "Sample Text" for One Input Field

@Regression
Scenario: Test Two Input Fields
	Given I Enter 10 in EnterA field
	And I Enter 20 in EnterB field
	And I click on Button Get Total
	Then I see the Output message as 30 for Two Input Field
