Feature: Calculator

# This is a single line comment
@mytag
Scenario: Add two numbers
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	#Then the result should be 120
	Then the result should be 121


