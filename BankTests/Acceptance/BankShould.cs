using Bank;
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
        
        account = new Account(cashSafe);
        
        // When
        account.Deposit(1000);
        account.Deposit(2000);
        account.Withdraw(500);
        
        // TODO: Find a way to assert the print since it is void
        account.PrintStatement();

        // Then
        Assert.Equal(2500, cashSafe.GetBalance());
    }
}