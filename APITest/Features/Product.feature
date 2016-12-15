Feature: Product
	In order to enable product purchasing
	As a merchendiser 
	I want to be enable product browsing

@smoke
Scenario: Return list of products
	Given I am a merchendiser interested in product management
	When I query for all products
	Then I am returned all saved products
