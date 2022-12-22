Feature: Increment the counter by n
    This feature lets a user increment the counter by n by clicking on the button.

Scenario: Basic increment n scenario
    Given I am on the counter-n page
    When I enter 23 into the user input
    When I click on the increment button
    Then The counter n should show "23"
