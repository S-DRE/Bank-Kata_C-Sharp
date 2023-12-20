using Bank;
using Bank.Helpers;
using Xunit;

namespace BankTest.Acceptance;

public class BankShould
{

    public Account account;
    
    [Fact]
    public void EndUpPrintingAllTheMovementsWithTheirCurrentBalance()
    {
        // Given
        CashSafe cashSafe = new CashSafe();
        ConsolePrinter consolePrinter = new ConsolePrinter();
        MovementRepository movementRepository = new MovementRepository();
        
        account = new Account(cashSafe, consolePrinter, movementRepository);
        
        // When
        account.Deposit(1000);
        account.Deposit(2000);
        account.Withdraw(500);
        
        // TODO: Find a way to assert the print since it is void
        account.PrintStatement();

        // Then
        Assert.Equal(2500, cashSafe.GetBalance());
        Assert.Equivalent(new List<IMovement>
        {
            new Movement(DateOnly.Parse("14/01/2012", GlobalVars.CULTURE_INFO), 1000, 1000),
            new Movement(DateOnly.Parse("14/01/2012", GlobalVars.CULTURE_INFO), 2000, 3000),
            new Movement(DateOnly.Parse("14/01/2012", GlobalVars.CULTURE_INFO), -500, 2500)
        }, movementRepository.GetMovements());
    }
}