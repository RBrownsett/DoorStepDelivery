Feature: ForgotPassword

tests for the forgot password feature

@forgotPassword
Scenario: I can view the forgot password page
	Given I am on the login page
	When I request the forgot password feature
	Then I can view the forgot password page
