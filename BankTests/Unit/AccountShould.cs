using Bank;
using Moq;
using Xunit;

namespace BankTest.Unit;

public class AccountShould
{

    public Account account;
    private readonly Mock<CashSafe> cashSafe = new();
    
    [Fact]
    public void AddMoneyInTheCashSafeWhenADepositIsMade()
    {
        account = new Account(cashSafe.Object);
        
        account.Deposit(500);
        
        cashSafe.Verify(safe => safe.AddCash(500));
    }
    
}