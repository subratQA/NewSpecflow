Feature: SimpleFormDemo
	This feature tests the simple form controls of Input Forms Main Page


Background: 
Given I Navigate to Demo Website
Then I see the page is loaded

@mytag
Scenario: 
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen
