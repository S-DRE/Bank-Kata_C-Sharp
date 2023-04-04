using Bank;
using Moq;

namespace BankUnitTests;

public class AccountShould
{
    private Account account;
    
    private Mock<WalletRepository> walletRepository = new();
    private Mock<DateCreator> dateMocker = new();


    public AccountShould()
    {
        account = new Account(new ProConsole(), dateMocker.Object, walletRepository.Object);
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
}