# <strong style="color:blue; opacity: 0.80">AP DOT NET CORE</strong>:mortar_board::computer: 
# <span style="color:green "> 1.Présentation de l'activité pratique</span>
 * <strong style="color:dark">Partie 1 :100: 
Partie 1 :  Créer une application DotNet Core de type console qui permet gérer des comptes (id, curency, balance)
   - Créer la classe Account
   - Créer l'interface AccountService avec les opérations :
         . AddNewAccount
         . GetAllAccounts
         . GetAccountById
         . GetDebitedAccounts
         . GetBalanceAVG()
   - Créer une implémentation de cette interface utilisant une collection de type Dictionary
   - Tester l'application

 * <strong style="color:dark">Partie 2 :
 Créer une application DotNet Core de type WebAPI qui permet gérer des produits appartenant à des catégories

# <span style="color:green "> 2.Partie de réalisation </span>
1. 	installation du .Net version 6.0
	
![](https://i.imgur.com/B59VUWa.png)

2. consultation de version

![](https://i.imgur.com/FMh8JSr.png)





3. Partie 1 :  
	Créer une application DotNet Core de type console qui permet gérer des comptes (id, curency, balance)


![](https://i.imgur.com/XjvSldp.png)

![](https://i.imgur.com/7zRTY9i.png)

![](https://i.imgur.com/kJy07ES.png)

   - Créer la classe Account

```csharp!
using System.Text.Json;

namespace FIRSTAPP.Service
{
    public class Account
    {
        public int id { get; set; }
        public string? currency { get; set; }
        public double balance { get; set; }

        public Account(){}

        public Account(int id, string currency, double balance)
        {
            this.id = id;
            this.currency = currency;
            this.balance = balance;
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}

```

   - Créer l'interface AccountService avec les opérations :
         . AddNewAccount
         . GetAllAccounts
         . GetAccountById
         . GetDebitedAccounts
         . GetBalanceAVG()

```csharp!
namespace FIRSTAPP.Service
{
    public interface AccountService
    {
        Account GetAccountById(int id);
        Account AddNewAccount(Account account1);
        List<Account> GetAllAccounts();
        Account UpdateAccount(Account account1);
        void DeleteAccount(int id);

        List<Account> GetDebitedAccounts();
        double balanceAVG();
    }
}
```

   - Créer une implémentation de cette interface utilisant une collection de type Dictionary

```csharp!
namespace   FIRSTAPP.Service
{
    class AccountServiceImpl : AccountService
    {
        private Dictionary<int,Account> accounts = new Dictionary<int, Account>() ;

        public void DeleteAccount(int id)
        {
            Account account = GetAccount(id);
            accounts.Remove(account.id);
        }

        public List<Account> GetAllAccounts()
        {
            return accounts.Values.ToList();
        }

        public Account GetAccount(int id)
        {
            //return accounts.Find(account => account.id == id);
            return this.accounts[id];
    
        }

        public Account UpdateAccount(Account account1)
        {
            Account account = GetAccount(account1.id);
            account.balance = account1.balance;
            account.currency = account1.currency;
            return account;
        }

        public List<Account> GetDebitedAccounts()
        {
            return this.accounts.Values.Where(account => account.balance < 0).ToList();
        }

        public double balanceAVG()
        {
            return this.accounts.Values.Average(account => account.balance);
        }

        public Account GetAccountById(int id)
        {
            return accounts.Values.ToList().Find(account => account.id == id);
        }

        public void AddNewAccount(Account account1)
        {
            accounts.Add(account1.id,account1);
        }
    }
}
```

   - Tester l'application

```csharp!
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
```

> Résultat de l'exécution
	
![](https://i.imgur.com/nIMX5Hs.png)


4. Partie 2 :
 Créer une application DotNet Core de type WebAPI qui permet gérer des produits appartenant à des catégories

![](https://i.imgur.com/Eu0b2jl.png)

* <strong style="color:dark"> Diagramme de classe
	
![](https://i.imgur.com/iVn4Zva.png)
