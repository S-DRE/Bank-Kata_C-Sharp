using Bank;
using Moq;

namespace AccountShould;

public class AccountShould
{
    private Account account;
    
    private Mock<WalletRepository> walletRepository = new();
    

    public AccountShould()
    {
        account = new Account(new ProConsole(), new DateCreator(), walletRepository.Object);
    }

    [Fact]
    public void DepositTheGivenAmountAndSaveTheValue() {
        account.Deposit(1000);
        walletRepository.Verify(wallet => wallet.add(1000));
    }
}