Feature: EnvironmentalAssessment

A short summary of the feature

@ssd
Scenario: Validate user should login application, add a record in Environment Assessment and delete a record in Environment Assessment and logout from application
Given user navigate to application
And user login to the application using Username and Password
        | UserName | Password |
		| SaiA    | Evo@87    |	
And user navigates to Environmental Assessment using modules drop down menu
When user selects click new record button
And user fills the assessment and description fields
Then click on save and close button
When user selects click new record button
And user fills the assessment and description fields
Then click on save and close button
When user deletes the first record 
Then only second record should be available
And logout from the application