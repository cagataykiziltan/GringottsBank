# GringottsBank
 
Bank

For running, 

1.First you must set up backup database.
2.Setting up connection string.
3.Get token from auth controller with basic authentication.
4.Call functions with and barear token you got from auth controller.


* Project coded according to DDD principles.

Presentation Layer : Layer which opens api to the world.
Application Layer    : Manages use cases with mediator pattern by calling domain methods and repositories.
Domain Layer            : Core business entities layers which include critical business data and rules.
Infrastructure Layer : Database operations like repositories&Unit of work and third party libraries.
Test Layer                   : Includes some unit tests for domain and application layers.


![1_x4O5ae2f8UzCXncyvqprMg](https://user-images.githubusercontent.com/45563744/150317081-2e3e26ed-1294-4b6d-bd04-e8fcac3651bf.jpeg)

Customer Api

- CreateCustomer : Creates new customer for bank.
- GetAllCustomerAccounts : Gets customer’s all account informations
- GetCustomerAccountDetails : Get Customer's one account's details

Account Api

- CreateAccount : Creates new customer for bank.
- AddMoney : Gets customer’s all account informations
- WithdrawMoney : Get Customer's one account's details
- GetAllAccountTransactions : Get all transcations of an account
- GetAccountTransactionBetweenPeriod : Get Transactions between period 


* MsSql database is selected because project needs strongly consistency because of financial operations and we can utilize ACID principles for that.

* EF Core was used as ORM.

* All http requests, httpresponse and httperror responses are standartized for communication on API layer.

* Jwt based authentication was used.

* All methods logged representatively with aspect oriented approach.




