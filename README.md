# FinalTaskSelenium
Project created for the final task of selenium and C# training

Task description

Launch URL: https://www.saucedemo.com/

UC-1 Test Login form with empty credentials:
Type any credentials into "Username" and "Password" fields.
Clear the inputs.
Hit the "Login" button.
Check the error messages: "Username is required".

UC-2 Test Login form with credentials by passing Username:
Type any credentials in username.
Enter password.
Clear the "Password" input.
Hit the "Login" button.
Check the error messages: "Password is required".

UC-3 Test Login form with credentials by passing Username & Password:
Type credentials in username which are under Accepted username are sections.
Enter password as secret sauce.
Click on Login and validate the title “Swag Labs” in the dashboard.

Provide parallel execution, add logging for tests and use Data Provider to parametrize tests. Make sure that all tasks are supported by these 3 conditions: UC-1; UC-2; UC-3.
Please, add task description as README.md into your solution!

To perform the task use the various of additional options:
Test Automation tool: Selenium WebDriver;
Browsers: 1) Firefox; 2) Edge;
Locators: CSS;
Test Runner: MSTest ;
[Optional] Patterns: 1) Singleton; 2) Adapter; 3) Strategy;
Test automation approach: BDD;
Assertions: FluentAssertions;
[Optional] Loggers: Serilog.



BDD for tests
UC-1

feature: login empty username empty
	
	background: open browser
	given: I go to "https://www.saucedemo.com/"

	scenario: access website
	given: I enter the username 
	and: I enter the password
	and: I delete the username
	and: I delete de password
	when: I click Login button
	then: The error message "Epic sadface: Username is required" is shown in red

UC-2

feature: login empty password empty
	
	background: open browser
	given: I go to "https://www.saucedemo.com/"

	scenario: access website
	given: I enter the username 
	and: I enter the password
	and: I delete de password
	when: I click Login button
	then: The error message "Epic sadface: Password is required" is shown in red

UC -3
feature: succesful login test
	
	background: open browser
	given: I go to "https://www.saucedemo.com/"

	scenario: access website
	given: I enter the username 
	and: I enter the password
	when: I click Login button
	then: The dashboard is shown with the text "Swag Labs" on the top of the mainpage website