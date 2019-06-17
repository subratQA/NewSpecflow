Feature: This feature is to create a new study in desginer application

Scenario: 01_Login into Desginer
	Given I Logged into Designer application
	Then I see desginer home page 

@Ignore
Scenario:02_Create New Study
	Given I Click on "Create New Study" link from Action Pallet
	And I entered Study Name,Study Label,Protocol,Protocol Label,Study Indication,Therapeutic Area,Client and Clicked on Save Button
	| Study Name | Study Label | Protocol | Protocol Label | Study Indication | Therapeutic Area | Client | Target App               | Labs |
	| Study1     | Study1      | Study1   | Study1         | Study1           | OTHER            | Sponsor1 | DataLabs 5.8x or greater | Yes  |
	
	Then I see study has been created successfully

#Scenario Outline: 03_Verify Labs components tabs "Attribute Mapping" and "Lab Mapping"
#	Given I Click on the "Study1" study having protocol "Sponsor1"
#	Given I click on "Labs" Tab
#	Then I Verify the subtabs <tabs>
#		
#	Examples: 
#	|tabs|
#	| Attribute Mappings |
#	| Lab Mappings       | 

Scenario: 03_Add a New Form
	Given I Selected Study "Study1" having Sponsor/Client "Sponsor1" from Home Page
	And  I click on "Forms" Tab
	And I click on "Add Form" link in Forms page
	And I entered "Form Name" as "NewForm1"
	And I entered "Form Label" as "NewFormLabel1"
	And I clicked on "Save" Icon
	#Then I see a notification "NewForm1 has been successfully added"
	Then I see form "NewForm1" in the table created 