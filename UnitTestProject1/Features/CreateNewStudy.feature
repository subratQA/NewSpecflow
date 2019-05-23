Feature: This feature is to create a new study in desginer application

Scenario: Login into Desginer
	Given I Logged into Designer application
	Then I see desginer home page 

Scenario:Create New Study
	Given I Click on Create New Study link from Action Pallet
	And I entered Study Name,Study Label,Protocol,Protocol Label,Study Indication,Therapeutic Area,Client
	| Study Name | Study Label | Protocol | Protocol Label | Study Indication | Therapeutic Area | Client |
	| Study1     | Study1      | Study1   | Study1         | Study1           | OTHER            | Study1 |
	
	And I Clicked on Save Button
	Then I see the Study has been created
