Feature: Login

As a user
I should only be able to login with a valid mobile number and password
@login
Scenario: I cannot login with invalid details
	Given I am on the login page
	When I enter invalid details and try to login 
	Then I am not logged in

@login
Scenario: Correct Login Page Title is Displayed
	Given I am on the login page
	Then the page title is displayed




