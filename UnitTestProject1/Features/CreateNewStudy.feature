Feature: This feature is to create a new study in desginer application

Scenario: 01_Login into Desginer
	Given I Logged into Designer application
	Then I see desginer home page 

Scenario:02_Create New Study
	Given I Click on "Create New Study" link from Action Pallet
	And I entered Study Name,Study Label,Protocol,Protocol Label,Study Indication,Therapeutic Area,Client and Clicked on Save Button
	| Study Name | Study Label | Protocol | Protocol Label | Study Indication | Therapeutic Area | Client | Target App               | Labs |
	| Study1     | Study1      | Study1   | Study1         | Study1           | OTHER            | Sponsor1 | DataLabs 5.8x or greater | Yes  |
	
	Then I see study has been created successfully

Scenario: 03_Verify Labs tab components fields "Attribute Mapping" and "Lab Mapping"
	#Given I Click on the "Study1" study having protocol "Sponsor1"
	And I click on "Labs" Tab
	Then I Verify the subtabs Attribute Mappings and Lab Mappings displayed 

