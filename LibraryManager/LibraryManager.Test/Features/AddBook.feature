Feature: AddBook
	In order to add a new book
	As a user
	I want to be able to add it correctly

Scenario Outline: Add a valid book
	Given I create a new  valid book (<Id>, <Title>, <Author>, <Description>)
	And ModelState is correct
	Then the system should return positive <StatusCode>

Examples:
	| Id | Title       | Author              | Description                                    | StatusCode |
	| 1  | Don Quixote | Miguel de Cervantes | Alonso Quixano, a retired country gentleman... | 200        |
	| 2  | Moby Dick   | Herman Melvill      | First published in 1851, Melville's...         | 200        |
    | 3  | The Odyssey | Homer               |                                                | 200        |
    
Scenario Outline: Add an invalid book
    Given I create a new invalid book (<Id>, <Title>, <Author>, <Description>)
    And ModelState is correct
    Then the system should return negative <StatusCode>
    And error message should be returned as well

Examples:
    | Id | Title        | Author                         | Description                                    | StatusCode |
    | 4  | Don Quixote  |                                | Alonso Quixano, a retired country gentleman... | 400        |
    | 5  |              | Herman Melvill                 | First published in 1851, Melville's...         | 400        |
    | 6  | The Odyssey  | Homer                          |                                                | 400        |
    | 1  | New Book     | New Author                     |                                                | 400        |
    | 7  | TitleLong    | AuthorLongerThan30CharactersIn |                                                | 400        |
