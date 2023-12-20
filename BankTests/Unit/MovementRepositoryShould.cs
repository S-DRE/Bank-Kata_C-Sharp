using Bank;
using Bank.Helpers;
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

    [Fact]
    public void AddMovementToTheListOfMovements()
    {
        movementRepo.AddMovement(DateOnly.Parse("14/01/2012", GlobalVars.CULTURE_INFO), 500, 500);
        
        Assert.Equivalent(new List<IMovement>
        {
            new Movement(DateOnly.Parse("14/01/2012", GlobalVars.CULTURE_INFO), 500, 500)
        }, movementRepo.GetMovements());
    }
}