using Bank;
using Moq;
using Xunit;

namespace BankTest.Unit;

public class AccountShould
{

    public Account account;
    private readonly Mock<ICashSafe> cashSafeMock = new();
    private readonly Mock<IConsolePrinter> consolePrinterMock = new();
    private readonly Mock<IMovementRepository> movementRepositoryMock = new();

    public AccountShould()
    {
        account = new Account(cashSafeMock.Object, consolePrinterMock.Object, movementRepositoryMock.Object);
    }

    [Fact]
    public void AddMoneyInTheCashSafeWhenADepositIsMade()
    {
        account.Deposit(500);
        
        cashSafeMock.Verify(safe => safe.AddCash(500));
    }

    [Fact]
    public void RemoveMoneyFromTheCashSafeWhenAWithdrawalIsMade()
    {
        account.Withdraw(500);
        
        cashSafeMock.Verify(safe => safe.RemoveCash(500));
    }

    [Fact]
    public void PrintWithProperFormattingTheHistoricOfMovements()
    {
        account.Deposit(1000);
        account.Withdraw(500);
        
        account.PrintStatement();

        consolePrinterMock.Verify(consolePrinter => consolePrinter.PrintLine("Date       || Amount || Balance"));
        consolePrinterMock.Verify(consolePrinter => consolePrinter.PrintLine("14/01/2012 || 1000   || 1000"));
        consolePrinterMock.Verify(consolePrinter => consolePrinter.PrintLine("14/01/2012 || -500   || 500"));
    }
}