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