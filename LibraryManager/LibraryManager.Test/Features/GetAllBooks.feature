Feature: GetAllBooks
	In order to use the library service
	As a user
	I want to be able to get all books

Scenario Outline: Get all books
	Given a new book model is created <Id>, <Author>, <Title> and <Description>
	And the new model is sent to the server
	When the books are requested
	Then successful status code should be returned
	And all books should be retrieved
Examples:
	| Id | Author         | Title               | Description   |
	| 5  | Lisa Halliday  | Asymmetry           | Just for test |
	| 6  | Rebecca Makkai | The Great Believers | Another test  |
