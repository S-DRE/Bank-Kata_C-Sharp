using Bank;
using Moq;

namespace BankTest.Unit;

public class AccountShould
{
    private readonly Account account;

    private readonly Mock<ProConsole> proConsoleMocker = new();
    private readonly Mock<WalletRepository> walletRepository = new();
    private readonly Mock<DateCreator> dateMocker = new();


    public AccountShould()
    {
        account = new Account(proConsoleMocker.Object, dateMocker.Object, walletRepository.Object);
    }

    [Theory]
    [InlineData(1000)]
    [InlineData(2000)]
    public void DepositTheGivenAmountAndSaveTheValue(int depositAmount) {
        dateMocker.Setup(x => x.CreateCurrentDate())
            .Returns(DateTime.Parse("01/01/2000"));
        
        account.Deposit(depositAmount);
        walletRepository.Verify(wallet => wallet.add(depositAmount));
    }
    
    [Fact]
    public void PerformPrintAListOfPreviousDepositsAndWithdrawals()
    {
        /*
         * Date       || Amount || Balance
            14/01/2012 || -500   || 2500
            13/01/2012 || 2000   || 3000
            10/01/2012 || 1000   || 1000
         */

        // Given
        dateMocker.SetupSequence(x => x.CreateCurrentDate())
            .Returns(DateTime.Parse("10/01/2012"))
            .Returns(DateTime.Parse("13/01/2012"))
            .Returns(DateTime.Parse("14/01/2012"));

        walletRepository.SetupSequence(x => x.getBalance())
            .Returns(1000)
            .Returns(3000)
            .Returns(2500);

        // When
        account.Deposit(1000);
        account.Deposit(2000);
        account.Withdraw(500);
        account.PrintStatement();
        
        // Then
        // It could also check a bunch of lines if the console has a method for stack of transactions
        proConsoleMocker.Verify(console => console.printLine("Date       || Amount || Balance"));
        proConsoleMocker.Verify(console => console.printLine("14/01/2012 || -500 || 2500"));
        proConsoleMocker.Verify(console => console.printLine("13/01/2012 || 2000 || 3000"));
        proConsoleMocker.Verify(console => console.printLine("10/01/2012 || 1000 || 1000"));
    }
}