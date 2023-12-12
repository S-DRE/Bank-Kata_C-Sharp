namespace Bank;

public class Account : AccountService
{
    private CashSafe cashSafe;
    
    public Account(CashSafe cashSafe)
    {
        this.cashSafe = cashSafe;
    }

    public void Deposit(int amount)
    {
        throw new NotImplementedException();
    }

    public void Withdraw(int amount)
    {
        throw new NotImplementedException();
    }

    public void PrintStatement()
    {
        throw new NotImplementedException();
    }
}