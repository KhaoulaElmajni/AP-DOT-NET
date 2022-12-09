namespace FIRSTAPP.Service
{
    public interface AccountService
    {
        Account GetAccount(int id);
        Account AddNewAccount(Account account1);
        List<Account> GetAllAccounts();
        Account UpdateAccount(Account account1);
        void DeleteAccount(int id);

        List<Account> GetDebitedAccounts();
        double balanceAVG();

     
    }
}