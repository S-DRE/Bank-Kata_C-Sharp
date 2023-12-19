using Bank;
using Xunit;

namespace BankTest.Unit;

public class MovementRepositoryShould
{
    private readonly MovementRepository movementRepo;
    
    public MovementRepositoryShould()
    {
        movementRepo = new MovementRepository();
    }

    [Fact]
    public void ReturnPrivateMovementsListWithAllMovements()
    {
        Assert.Equal(new List<IMovement>(), movementRepo.GetMovements());
    }
}