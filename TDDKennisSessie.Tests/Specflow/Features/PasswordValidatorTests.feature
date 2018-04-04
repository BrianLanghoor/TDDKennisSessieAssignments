Feature: PasswordValidatorTests
	In order to avoid a silly password
	As a user
	I want to be told if my password is not safe enough

@mytag
Scenario: Given a valid password when validated the password should be valid
	Given a valid password
	When I validate that password
	Then the password validation result should be valid

Scenario: Given a invalid password when validated the password should be invalid
	Given a invalid password
	When I validate that password
	Then the password validation result should be invalid

Scenario: Given a password with seven characters the password should be invalid
	Given the password 1234567
	When I validate that password
	Then the password validation result should be invalid

Scenario: Given a password with seven characters the error message should be: Password must contain between 8-15 characters.
	Given the password 123ABCa
	When I validate that password
	Then the error message should be: Password must be longer than 8 characters.

Scenario: Given a password without a number the error message should be: Password must at least contain one number.
	Given the password ABCDabcd
	When I validate that password
	Then the error message should be: Password must at least contain one number.

Scenario: Given a password without a capital letter the error message should be: Password must at least contain one capital letter.
	Given the password 123abcdefg
	When I validate that password
	Then the error message should be: Password must at least contain one capital letter.

#Assignment 3
#Create new tests where the validator takes a maximum length of 15 in account
#Also the validator has to check that there is at least one non-capital letter.