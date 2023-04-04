namespace Bank;

public interface WalletRepository
{
    public void add(int amount);
    void remove(int amount);
    public int getBalance();
}