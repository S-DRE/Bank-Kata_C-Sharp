using Bank.Helpers;

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

    public void Deposit(DateOnly date, int amount)
    {
        movementRepository.AddMovement(date, amount, cashSafe.GetBalance()+amount);
        cashSafe.AddCash(amount);
    }

    public void Withdraw(DateOnly date, int amount)
    {
        movementRepository.AddMovement(date, amount * -1, cashSafe.GetBalance()-amount);
        cashSafe.RemoveCash(amount);
    }

    public void PrintStatement()
    {
        consolePrinter.PrintLine(HEADER);

        var movements = movementRepository.GetMovements();

        movements.Reverse();

        foreach (var movement in movements) {
            consolePrinter.PrintLine(movement.GetDate() + " || " + movement.GetTransactionValue() + "   || " + movement.GetOutputBalance());
        }
    }
}
