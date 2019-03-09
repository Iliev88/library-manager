Feature: DeleteBook
	In order to use the library service
	As a user
	I want to be be able to delete a book

Scenario Outline: Delete a book
	Given book model is created <Id>, <Author>, <Title> and <Description>
	And the model is sent to the server
	When book is deleted <Id>
	Then successful status code for deletion should be returned
Examples:
	| Id | Author        | Title             | Description    |
	| 7  | Leila Slimani | The Perfect Nanny | Testing around |

Scenario Outline: Fail to delete a book
	Given book is deleted <Id>
	Then error message <Error>
Examples:
	| Id  | Error |
	| 999 | not found! |
	| -1  | not found! |
	| 0   | not found! |
