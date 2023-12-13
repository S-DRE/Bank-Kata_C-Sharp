using Bank;
using Moq;
using Xunit;

namespace BankTest.Unit;

public class AccountShould
{

    public Account account;
    private readonly Mock<ICashSafe> cashSafeMock = new();
    
    [Fact]
    public void AddMoneyInTheCashSafeWhenADepositIsMade()
    {
        account = new Account(cashSafeMock.Object);
        
        account.Deposit(500);
        
        cashSafeMock.Verify(safe => safe.AddCash(500));
    }
    
}