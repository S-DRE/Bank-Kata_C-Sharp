namespace Bank;

public class MovementRepository : IMovementRepository
{
    private readonly List<IMovement> movementsList = new();
    
    public List<IMovement> GetMovements()
    {
        return movementsList;
    }
}