Feature: AddBook
	In order to use library service
	As a user
	I want to be able to add a book

Scenario Outline: Add a book
	Given book model is created <Id>, <Author>, <Title> and <Description>
	When the model is sent to the server
	Then successful status code should be returned
	And the book should be available
Examples:
	| Id | Author              | Title       | Description                          |
	| 1  | Miguel de Cervantes | Don Quixote | Alonso Quixano, a retired country... |
	| 2  | James Joyce         | Ulysses     | Ulysses chronicles the passage...    |
	| 3  | Krisko              | The Road    |                                      |

Scenario Outline: Fail to add a book
   Given book model is created <Id>, <Author>, <Title> and <Description>
   When the model is sent to the server
   Then unsuccessful status code should be returned
   And error message <Error>
Examples:
	| Id | Author                           | Title          | Description          | Error                                       |
	| 4  |                                  | Random Title 4 | Random Description 4 | Book.Author is a required field             |
	| 5  | Random Author 5                  |                | Random Description 5 | Book.Title is a required field              |
	| -1 | Invalid Author                   | Invalid Title  | Invalid Description  | Book.Id should be a positive integer!       |
	| 0  | Invalid Author                   | Invalid Title  | Invalid Description  | Book.Id should be a positive integer!       |
	| 10 | AuthorLongerThanThirtyCharacters | Title          | Description          | Book.Author should not exceed 30 characters |

