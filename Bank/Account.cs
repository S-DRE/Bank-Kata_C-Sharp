namespace Bank;

public class Account
{
    private ProConsole proConsole;
    private DateCreator dateCreator;
    private WalletRepository wallet;

    public Account(ProConsole proConsole, DateCreator dateCreator, WalletRepository wallet)
    {
        this.proConsole = proConsole;
        this.dateCreator = dateCreator;
        this.wallet = wallet;
    }

    public void Deposit(int amount)
    {
        wallet.add(1000);
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