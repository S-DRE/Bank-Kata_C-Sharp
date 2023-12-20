namespace Bank;

public static class Bank
{
    static void Main(string[] args)
    {
        /*
       * Date       || Amount || Balance
         14/01/2012 || -500   || 2500
         14/01/2012 || 2000   || 3000
         14/01/2012 || 1000   || 1000
       */

        var consolePrinter = new ConsolePrinter();
        var cashSafe = new CashSafe();
        var movementRepo = new MovementRepository();

        
        var account = new Account(cashSafe, consolePrinter, movementRepo);

        
        account.Deposit(1000);
        account.Deposit(2000);
        account.Withdraw(500);
        account.PrintStatement();
    }
}