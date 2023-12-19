using Bank;
using Xunit;

namespace BankTest.Unit;

public class MovementShould
{

    private readonly Movement movement;
    
    public MovementShould()
    {
        movement = new Movement(DateOnly.Parse("14/12/2012"), 1000, 5000);
    }
    
    [Fact]
    public void RetrieveDateWhenAsked()
    {
        Assert.Equal(DateOnly.Parse("14/12/2012"), movement.GetDate());
    }
}