Feature: BankAccount

Scenario: DebitMoneySuccess
	Given the balance is 100
	And the account number is 123
	When debit money is 100
	Then the balance should be 0

Scenario: DebitMoneyFail
	Given the balance is 0
	And the account number is 123
	When debit money is 100
	Then the user is presented with an error message