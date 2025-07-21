Feature: Library Manager API

  Background:
    Given the service is started

  Scenario: Get all books
    When I request all books
    Then the response should contain a list of books

  Scenario: Add and get a book
    When I add a new book
    And I get the book by ID
    Then the book data should match

  Scenario: Update a book
    Given I have added a new book
    When I update the book
    Then the updated data should be returned

  Scenario: Delete a book
    Given I have added a new book
    When I delete the book
    Then getting the book should return not found
