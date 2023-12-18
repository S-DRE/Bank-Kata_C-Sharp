namespace Bank;

public interface IMovementRepository
{
    public List<IMovement> GetMovements();
}