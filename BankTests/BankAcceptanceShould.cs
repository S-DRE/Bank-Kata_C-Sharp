using Bank;
using Moq;

namespace BankTests;

public class BankAcceptanceShould
{
    [Fact]
    public void PerformPrintAListOfPreviousDepositsAndWithdrawals()
    {
        /*
         * Date       || Amount || Balance
            14/01/2012 || -500   || 2500
            13/01/2012 || 2000   || 3000
            10/01/2012 || 1000   || 1000
         */

        var consoleMocker = new Mock<ProConsole>();
        ProConsole proConsoleMock = consoleMocker.Object;

        var dateMocker = new Mock<DateCreator>();
        DateCreator dateCreatorMock = dateMocker.Object;

        var walletInMemoryRepo = new Wallet();

        // given
        var account = new Account(proConsoleMock, dateCreatorMock, walletInMemoryRepo);
        dateMocker.SetupSequence(x => x.CreateCurrentDate())
            .Returns(DateTime.Parse("14/01/2012"))
            .Returns(DateTime.Parse("13/01/2012"))
            .Returns(DateTime.Parse("10/01/2012"));

        // when
        account.Deposit(1000);
        account.Deposit(2000);
        account.Withdraw(500);
        account.PrintStatement();
        
        // then
        
        // It could also check a bunch of lines if the console has a method for stack of transactions
        consoleMocker.Verify(console => console.printLine("Date       || Amount || Balance"));
        consoleMocker.Verify(console => console.printLine("14/01/2012 || -500   || 2500"));
        consoleMocker.Verify(console => console.printLine("13/01/2012 || 2000   || 3000"));
        consoleMocker.Verify(console => console.printLine("10/01/2012 || 1000   || 1000"));
        
    }
}

