namespace Bank;

public class Account
{
    private ProConsole proConsole;
    private DateCreator dateCreator;

    public Account(ProConsole proConsole, DateCreator dateCreator)
    {
        this.proConsole = proConsole;
        this.dateCreator = dateCreator;
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