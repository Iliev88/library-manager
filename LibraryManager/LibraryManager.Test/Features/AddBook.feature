Feature: AddBook
	In order to test adding books to library
	As a librarian
	I want to be able to add relevant books

Scenario Outline: Add a book
	Given I create a new book (<Id>, <Title>, <Author>, <Description>)
	And ModelState is correct
	Then the system should return <StatusCode>

Examples:
	| Id | Title   | Author   | Description   | StatusCode |
	| 1  | Title 1 | Author 1 | Description 1 | 200        |
	| 2  | Title 2 | Author 2 | Description 2 | 200        |
