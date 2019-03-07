Feature: AddBook
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario Outline: Add a book
	Given book model is created <Id>, <Author>, <Title> and <Description>
	When the model is sent to the server
	Then successful status code should be returned
	And the book should be added
Examples:
	| Id | Author              | Title       | Description                          |
	| 1  | Miguel de Cervantes | Don Quixote | Alonso Quixano, a retired country... |
	| 2  | James Joyce         | Ulysses     | Ulysses chronicles the passage...    |
	| 3  | Krisko              | The Road    |                                      |

Scenario Outline: Fail to add a book
   Given book model is created <Id>, <Author>, <Title> and <Description>
   When the model is sent to the server
   Then the book should not be added <Error>
   And unsuccessful status code should be returned
Examples:
	| Id | Author          | Title          | Description          | Error                           |
	| 1  | Random Author   | Random Title   | Random Description   | already exists!                 |
	| 4  |                 | Random Title 4 | Random Description 4 | Book.Author is a required field |
	| 5  | Random Author 5 |                | Random Description 5 | Book.Title is a required field  |

