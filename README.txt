The purpose of the program is to imitate a banking application for a customer at a bank. 
This required features such as: multiple bank accounts per user in different currencies, the ability to take out a loan, 
the ability to transfer data between accounts, a inbuilt delay in all transactions so that banks can monitor transactions and much more.


brief description of important classes:
Start.cs: 
This is where the code goes right after initiliazation and handles login and begins background task "DelayedTransaction.StartDelayedTransactions();"

DelayedTransaction.cs:
This the where all transactions are stored as they wait to be proccessed. Every 15 min all transactions in the backlog are executed.

Account.cs:
This is the template for every account a user can have, be it savings or checkings or whatever currency they want to use.

User.cs:
This template represents a single user with all their information and a List<Accounts> with all their accounts.

Menu.cs:
After a successful login the user goes to the menu where all options such as deposit, withdraw, create new account and so on exist. 
This is the heart of the program as every action except logging in begin and end in the menu.

GetUserInput.cs:
This gives developers easy access to simple things like getting strings from users.

StartUpAction.cs:
This file creates users for testing purposes.

MenuEndpoints FOLDER:
This folder contains classes with all the metohds displayed in the menu

MenuOptions.cs:
This is where many of the shorter features are located such as and withdraw, deposit and create new account. 
The reason not all methods displayed in the menu are in this class is beacause some methods take up just 20 lines of code while some contain over 200.
Which would make this class difficult to manouver.

Transfer.cs:
This is one of the large methods displayed in the menu. It handles trasnfers between accounts 
both internally (your own account to another of your account) and externally(to another user).