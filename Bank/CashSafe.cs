namespace Bank;

public class CashSafe : ICashSafe
{

    private int balance = 0;
    
    public int GetBalance()
    {
        return balance;
    }

    public void AddCash(int amount)
    {
        balance += amount;
    }
    
    public void RemoveCash(int amount)
    {
        balance -= amount;
    }
}