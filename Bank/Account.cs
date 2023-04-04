namespace Bank;

public class Account
{
    private ProConsole proConsole;
    private DateCreator dateCreator;
    private WalletRepository wallet;
    private List<Movement> movements = new();

    public Account(ProConsole proConsole, DateCreator dateCreator, WalletRepository wallet)
    {
        this.proConsole = proConsole;
        this.dateCreator = dateCreator;
        this.wallet = wallet;
    }

    public void Deposit(int amount)
    {
        wallet.add(amount);
        AddMovement(amount);
    }

    public void Withdraw(int amount)
    {
        wallet.remove(amount);
        AddMovement(amount*-1);
    }

    public void PrintStatement()
    {
        proConsole.printLine("Date       || Amount || Balance");

        for(int i=movements.Count-1; i>=0; i--)
        {
            proConsole.printLine(FormatLine(i));
        }
        
    }

    private void AddMovement(int amount)
    {
        movements.Add(new Movement(dateCreator.CreateCurrentDate(), amount, wallet.getBalance()));
    }
    
    private string FormatLine(int index)
    {
        return movements[index].date.ToString("dd/MM/yyyy") + " || " +
               movements[index].operationAmount + " || " +
               movements[index].remainingBalance;
    }
}