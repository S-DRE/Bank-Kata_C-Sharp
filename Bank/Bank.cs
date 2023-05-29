namespace Bank;

public static class Bank
{
    static void Main(string[] args)
    {
        /*
        * Date       || Amount || Balance
          29/05/2023 || -500   || 2500
          29/05/2023 || 2000   || 3000
          29/05/2023 || 1000   || 1000
        */

        var console = new ProConsole();
        var dateCreator = new DateCreator();
        var walletInMemoryRepo = new Wallet();

        
        var account = new Account(console, dateCreator, walletInMemoryRepo);

        
        account.Deposit(1000);
        account.Deposit(2000);
        account.Withdraw(500);
        account.PrintStatement();
    }
}