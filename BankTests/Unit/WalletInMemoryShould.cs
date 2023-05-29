using Bank;

namespace BankTest.Unit;

public class WalletInMemoryShould
{
    private readonly WalletInMemory _walletInMemory;

    public WalletInMemoryShould()
    {
        _walletInMemory = new();
    }
    
    [Fact]
    public void BeInitializedWithABalanceOf0()
    {
        Assert.Equal(0, _walletInMemory.getBalance());
    }
    
    [Theory]
    [InlineData(1000)]
    [InlineData(2000)]
    public void AddGivenAmountToTheBalanceWhenADepositIsMade(int depositAmount)
    {
        _walletInMemory.add(depositAmount);

        Assert.Equal(depositAmount, _walletInMemory.getBalance());
    }
    
    [Theory]
    [InlineData(10000, 1000, 9000)]
    [InlineData(10000, 2000, 8000)]
    public void RemoveGivenAmountToTheBalanceWhenAWithdrawIsMade(int startingAmount, int withdrawAmount, int expectedAmount)
    {
        _walletInMemory.add(startingAmount);
        _walletInMemory.remove(withdrawAmount);

        Assert.Equal(expectedAmount, _walletInMemory.getBalance());
    }
}