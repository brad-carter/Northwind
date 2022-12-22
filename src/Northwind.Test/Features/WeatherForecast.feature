Feature: Get Weather Forecast
	 To get the weather forecast 

Scenario: Get the weather forecast for tomorrow
	Given the weather forecast 
	When I get the forecast for tomorrow
	Then the forecast temperature F should be greater than 0

Scenario: Cannot forecast the past
	Given the weather forecast
	When I get the forecast for yesterday
	Then the service should throw an argument exception

Scenario: Get the weather forecast for a given temperature
	Given the weather forecast for 70
	Then the forecast should be Mild