Feature: Employees

Scenario: Check that Hallstein is still employed
    Given I navigate to "https://www.novanet.no"
    When I click the link "MENNESKENE"
    Then the text "Hallstein Brøtan" is visible