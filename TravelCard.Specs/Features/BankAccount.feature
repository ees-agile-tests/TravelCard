Feature: BankAccount

Scenario: DebitMoney
	Given the balance is 100
	And the account number is 123
	When debit money 100
	Then the balance should be 0

Scenario: DepositMoney
	Given the balance is 0
	And the account number is 123
	When deposit money 100
	Then the balance should be 100