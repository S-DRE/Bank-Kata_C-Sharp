namespace Bank;

public interface AccountService
{
    void Deposit(DateOnly date, int amount);
    void Withdraw(DateOnly date, int amount);
    void PrintStatement();
}
