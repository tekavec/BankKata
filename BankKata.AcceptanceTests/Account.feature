Feature: Account
	

@mytag
Scenario: Print the statement
	Given a client makes a deposit of 1000 on '10/01/2012'
	And a deposit of 2000 on '13/01/2012'
	And a withdrawal of 500 on '14/01/2012'
	When she prints her bank statement
	Then she would see
| Date       | Amount  | Balance |
| 14/01/2012 | -500.00 | 2,500.00 |
| 13/01/2012 | 2,000.00 | 3,000.00 |
| 10/01/2012 | 1,000.00 | 1,000.00 |