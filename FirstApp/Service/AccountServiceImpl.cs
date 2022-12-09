namespace   FIRSTAPP.Service
{
    class AccountServiceImpl : AccountService
    {
        private List<Account> accounts = new List<Account>();
        public Account AddNewAccount(Account account1)
        {
            this.accounts.Add(account1);
            return account1;
        }

        public void DeleteAccount(int id)
        {
            Account account = GetAccount(id);
            accounts.Remove(account);
        }

        public List<Account> GetAllAccounts()
        {
            return accounts;
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
            return this.accounts.Where(account => account.balance < 0).ToList();
        }

        public double balanceAVG()
        {
            throw new NotImplementedException();
        }
    }
}