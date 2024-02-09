Feature: Google Search Example
	Test example of Specflow and Selenium Webdriver

###############################################
#This is a comment
################################################

@GoogleSearchFeature
Scenario Outline: GoogleSearchFeature
	Given I Open a "<Browser>" to "www.google.com"
	And I search for "Books"
	#When I click on the Amazon link
	When I click on the link "<LinkText>"
	#Then the number of page images are 163
	Then the number of page images are <count>

	Examples:
	| Browser | LinkText | count |
	| Chrome  | Amazon   | 163   |
	| FireFox | Amazon   | 163   |
	| Edge    | Amazon   | 163   |


