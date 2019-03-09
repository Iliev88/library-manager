Feature: UpdateBook
	In order to use the librabry service
	As a user
	I want to be able to update a book

Scenario Outline: Update a book
	Given book model is created <Id>, <Author>, <Title> and <Description>
	And the model is sent to the server
	When the book is updated <IdEdit>, <AuthorEdit>, <TitleEdit>, <DescriptionEdit>
	Then successful status code should be returned
	And updated book should be returned as well
Examples:
	| Id | Author | Title       | Description                          | IdEdit | AuthorEdit | TitleEdit | DescriptionEdit |
	| 8  | Miguel | Don Quixote | Alonso Quixano, a retired country... | 8      |edit        | edit      | edit            |

Scenario Outline: Fail to update a book
	Given book model is created <Id>, <Author>, <Title> and <Description>
	And the model is sent to the server
	When the book is updated <IdEdit>, <AuthorEdit>, <TitleEdit>, <DescriptionEdit>
	Then unsuccessful status code should be returned
	And error message <Error>
Examples:
	| Id | Author | Title       | Description                          | IdEdit | AuthorEdit | TitleEdit | DescriptionEdit | Error                           |
	| 9  | Miguel | Don Quixote | Alonso Quixano, a retired country... | 9      |            | edit      | edit            | Book.Author is a required field |
	| 9  | Miguel | Don Quixote | Alonso Quixano, a retired country... | 9      | edit       |           | edit            | Book.Title is a required field  |


