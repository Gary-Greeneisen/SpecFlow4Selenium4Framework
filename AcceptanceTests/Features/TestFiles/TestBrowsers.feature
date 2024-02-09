Feature: TestBrowsers Example
	Test example of Specflow and Selenium Webdriver

###############################################
#This is a comment
################################################

@TestBrowsersFeature
Scenario Outline: TestBrowsersFeature
	Given I Open a "<Browser>" 
	And I Goto to "www.google.com"
	When I search for "<SearchText>"
	#When I click on the Amazon link
	Then I can count the number of page images

	Examples:
	| Browser | SearchText |
	| Chrome  | Amazon     |
	| FireFox | Amazon     |
	| Edge    | Amazon     |
