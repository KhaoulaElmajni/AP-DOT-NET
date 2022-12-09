// See https://aka.ms/new-console-template for more information
using FIRSTAPP.Service;

Console.WriteLine("Hello, World!");
Console.WriteLine("Test Dot Net core!");
Console.WriteLine("your name :");
String name = Console.ReadLine();
Console.WriteLine("Hello, " + name);

Account account = new Account(1, "USD", 1000);

Console.WriteLine(account.ToString());

AccountService accountService = new AccountServiceImpl();
accountService.AddNewAccount(account);
accountService.AddNewAccount(new Account(2, "USD", 2000));
accountService.AddNewAccount(new Account(3, "USD", 3000));
accountService.AddNewAccount(new Account(4, "USD", 4000));
accountService.AddNewAccount(new Account(5, "USD", 5000));
accountService.AddNewAccount(new Account(6, "USD", 6000));

accountService.GetAllAccounts().ForEach(account => Console.WriteLine(account.ToString()));

accountService.GetDebitedAccounts().ForEach(account => Console.WriteLine(account.ToString()));

Console.WriteLine(accountService.balanceAVG());

Console.WriteLine(accountService.GetAccountById(1).ToString());

accountService.DeleteAccount(1);