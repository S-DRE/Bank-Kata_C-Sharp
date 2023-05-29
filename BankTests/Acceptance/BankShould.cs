using Bank;

namespace BankTest.Acceptance;

public class BankShould
{

    [Fact]
    public void EndUpPrintingAllTheMovementsWithTheirCurrentBalance()
    {
        // Given
        var console = new ProConsole();
        var dateCreator = new DateCreator();
        var walletInMemoryRepo = new WalletInMemory();

        // When
        var account = new Account(console, dateCreator, walletInMemoryRepo);

        account.Deposit(1000);
        account.Deposit(2000);
        account.Withdraw(500);
        account.PrintStatement();
        
        // Then
        Assert.Equal(2500, walletInMemoryRepo.getBalance());
    }
}

