Feature: Select study and create domain, colelist

Scenario: 01_Login into Desginer
	Given I Logged into Designer application
	Then I see desginer home page 


Scenario: 02_Add a New Form
	Given I Selected Study "Study1" having Sponsor/Client "Sponsor1" from Home Page
	#And  I click on "Forms" Tab
	#And I click on "Add Form" link in Forms page
	#And I entered Form Name as "NewForm"
	#And I entered Form Label as "NewFormLabel"
	#And I clicked on "Save" Icon
	Then I see a notification "NewForm has been successfully added"

#Scenario: 03_Verify Labs components tabs "Attribute Mapping" and "Lab Mapping"
#	#Given I Click on the "Study1" study having protocol "Sponsor1"
#	And I click on "Labs" Tab
#	Then I Verify the subtabs <tabs>
#	Examples: 
#	|tabs|
#	| Attribute Mappings |
#	| Lab Mappings       | 

