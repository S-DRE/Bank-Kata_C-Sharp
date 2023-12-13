using Bank;
using Xunit;

namespace BankTest.Unit;

public class CashSafeShould
{
    public CashSafe cashSafe;

    [Fact]
    public void RetrieveTheDefaultBalanceValueIfNoOperationIsMade()
    {
        cashSafe = new CashSafe();
        
        Assert.Equal(0, cashSafe.GetBalance());
    }

    [Fact]
    public void AddTheSpecifiedAmountToTheSafeBalance()
    {
        cashSafe = new CashSafe();
        
        cashSafe.AddCash(500);
        
        Assert.Equal(500, cashSafe.GetBalance());
    }
    
    [Fact]
    public void RemoveTheSpecifiedAmountFromTheSafeBalance()
    {
        cashSafe = new CashSafe();
        
        cashSafe.AddCash(1000);
        cashSafe.RemoveCash(700);
        
        Assert.Equal(300, cashSafe.GetBalance());
    }
    
    [Fact]
    public void AllowBalanceToIncurInDebt()
    {
        cashSafe = new CashSafe();
        
        cashSafe.AddCash(1000);
        cashSafe.RemoveCash(1300);
        
        Assert.Equal(-300, cashSafe.GetBalance());
    }
}