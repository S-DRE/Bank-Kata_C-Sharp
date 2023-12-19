namespace Bank;

public class Account : AccountService
{
    private readonly ICashSafe cashSafe;
    private readonly IConsolePrinter consolePrinter;
    private readonly IMovementRepository movementRepository;
    
    private const string HEADER = "Date       || Amount || Balance";
    private const string fixedDateForKataPurposes = "14/01/2012";
    
    public Account(ICashSafe cashSafe, IConsolePrinter consolePrinter, IMovementRepository movementRepository)
    {
        this.cashSafe = cashSafe;
        this.consolePrinter = consolePrinter;
        this.movementRepository = movementRepository;
    }

    public void Deposit(int amount)
    {
        movementRepository.AddMovement(DateOnly.Parse(fixedDateForKataPurposes), amount, cashSafe.GetBalance()+amount);
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
            consolePrinter.PrintLine(movement.GetDate() + " || " + movement.GetTransactionValue() + " || " + movement.GetOutputBalance());
        }
    }
}