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
        
        List<DateOnly> testingDates = new List<DateOnly>
        {
            new (2010, 1, 10),
            new (2012, 1, 12),
            DateOnly.Parse("14/01/2012", GlobalVars.CULTURE_INFO)
        };

        List<IMovement> expectedMovements = new()
        {
            new Movement(testingDates[2], -500, 2500),
            new Movement(testingDates[1], 2000, 3000),
            new Movement(testingDates[0], 1000, 1000)
        };
        
        account = new Account(cashSafe, consolePrinter, movementRepository);
        
        // When
        account.Deposit(testingDates[0],1000);
        account.Deposit(testingDates[1],2000);
        account.Withdraw(testingDates[2],500);
        
        // TODO: Find a way to assert the print since it is void
        account.PrintStatement();

        // Then
        Assert.Equal(2500, cashSafe.GetBalance());
        Assert.Equivalent(expectedMovements, movementRepository.GetMovements());

        // Assert.True(movementRepository.GetMovements().SequenceEqual(expectedMovements));
    }
}
