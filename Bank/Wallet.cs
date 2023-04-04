namespace Bank;

public class Wallet : WalletRepository
{
    private int balance = 0;
    
    public void add(int amount)
    {
        balance += amount;
    }

    public void remove(int amount)
    {
        balance -= amount;
    }

    public int getBalance()
    {
        return balance;
    }
}