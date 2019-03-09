Feature: GetBook
	In order to use the library service
	As a user
	I want to be able to get a book

Scenario Outline: Get a book
	Given book model is created <Id>, <Author>, <Title> and <Description>
	And the model is sent to the server
	When book is requested <Id>
	Then successful status code should be returned
	And the book should be available
Examples:
	| Id | Author    | Title   | Description |
	| 4  | Dan Brown | Inferno | Dante...    |

Scenario Outline: Get an invalid book
	Given book is requested <Id>
	Then not found status code should be returned
	And book should not be retrieved <Error>
Examples: 
	| Id  | Error      |
	| 999 | not found! |
	| -1  | not found! |
	| 0   | not found! |

