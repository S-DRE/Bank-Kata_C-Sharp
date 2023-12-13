namespace Bank;

public class Account : AccountService
{
    private readonly ICashSafe cashSafe;
    
    public Account(ICashSafe cashSafe)
    {
        this.cashSafe = cashSafe;
    }

    public void Deposit(int amount)
    {
        cashSafe.AddCash(amount);
    }

    public void Withdraw(int amount)
    {
        cashSafe.RemoveCash(amount);
    }

    public void PrintStatement()
    {
        throw new NotImplementedException();
    }
}