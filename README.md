# Mobile-Banking-App

This mobile banking application is a console application that replicates a real world mobile banking application with functionalities for both customers and administrators.

## Features

### General features:

1. There are two types of accounts that can be created: Current account and Savings Account
2. The application uses excel files for data storage and access.

### Administrator features:

1. The administrator logs into the application with a username and password assigned by the master administrator manually.
2. The administrator can create a new customer account.
3. The administrator can modify certain details of an existing customer.
4. The administrator can delete the account of an existing customer.

### Customer features:

1. Customers login to the application with a login pin assigned to them when the administrator creates a new account.
2. Customers can withdraw money from the account subject to certain restrictions with respect to balances.
3. Customers can deposit money into their account subject to certain restrictions with respect to ceiling on amount that can be deposited per transaction.
4. Customers can view balance in their account.
5. Customers can transfer money to a third party account.
6. Customers can view a mini account statement that displays their recent 10 transactions.

### Libraries used:

1. Autofac - For dependancy injection
2. Epplus - For working with Excel files for data storage and access
3. FluentValidation - For data validation
