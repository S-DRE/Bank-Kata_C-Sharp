namespace Bank;

public interface ICashSafe
{
    public int GetBalance();

    public void AddCash(int amount);
}