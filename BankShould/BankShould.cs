using Bank;
using Moq;

namespace BankShould;

public class BankShould
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

        var consoleMock = new Mock<ProConsole>();
        ProConsole proConsoleMock = consoleMock.Object;

        // given
        var account = new Account(proConsoleMock);

        // when
        account.Deposit(1000, new Date("10/01/2012"));
        account.Deposit(2000, new Date("13/01/2012"));
        account.Withdraw(500, new Date("14/01/2012"));
        account.PrintStatement();
        
        // then
        
        // It could also check a bunch of lines if the console has a method for stack of transactions
        consoleMock.Verify(console => console.printLine("Date       || Amount || Balance"));
        consoleMock.Verify(console => console.printLine("14/01/2012 || -500   || 2500"));
        consoleMock.Verify(console => console.printLine("13/01/2012 || 2000   || 3000"));
        consoleMock.Verify(console => console.printLine("10/01/2012 || 1000   || 1000"));
        
    }
}

