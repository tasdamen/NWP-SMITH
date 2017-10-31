Feature: ProductCategory1
	○ Extend ProductAPI by adding category functionality:
			§ List all the categories;
			§ Filter products by category;
			§ Add corresponding SpecFlow scenarios;

@mytag
Scenario: List all the categories
	Given  I have a connection to the database
    When I connect to  "http://adm-newpapi:9000/api/Catagories/"
	Then I get a list of X Categories
