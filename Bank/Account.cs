namespace Bank;

public class Account : AccountService
{
    private readonly ICashSafe cashSafe;
    private readonly IConsolePrinter consolePrinter;
    private readonly IMovementRepository movementRepository;
    
    private const string HEADER = "Date       || Amount || Balance";
    
    public Account(ICashSafe cashSafe, IConsolePrinter consolePrinter, IMovementRepository movementRepository)
    {
        this.cashSafe = cashSafe;
        this.consolePrinter = consolePrinter;
        this.movementRepository = movementRepository;
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
        consolePrinter.PrintLine(HEADER);

        var movements = movementRepository.GetMovements();

        foreach (var movement in movements) {
            consolePrinter.PrintLine(movement.GetDate() + "||" + movement.GetTransactionValue() + "||" + movement.GetOutputBalance());
        }
    }
}