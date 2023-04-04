using Bank;

namespace BankUnitTests;

public class WalletShould
{
    private Wallet wallet;

    public WalletShould()
    {
        wallet = new();
    }
    
    [Fact]
    public void beInitializedWithABalanceOf0()
    {
        Assert.Equal(0, wallet.getBalance());
    }
    
    [Theory]
    [InlineData(1000)]
    [InlineData(2000)]
    public void AddGivenAmountToTheBalanceWhenADepositIsMade(int depositAmount)
    {
        wallet.add(depositAmount);

        Assert.Equal(depositAmount, wallet.getBalance());
    }
    
    [Theory]
    [InlineData(10000, 1000, 9000)]
    [InlineData(10000, 2000, 8000)]
    public void RemoveGivenAmountToTheBalanceWhenAWithdrawIsMade(int startingAmount, int withdrawAmount, int expectedAmount)
    {
        wallet.add(startingAmount);
        wallet.remove(withdrawAmount);

        Assert.Equal(expectedAmount, wallet.getBalance());
    }
}