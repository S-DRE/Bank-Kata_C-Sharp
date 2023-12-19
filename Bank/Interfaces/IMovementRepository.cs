namespace Bank;

public interface IMovementRepository
{
    public List<IMovement> GetMovements();
    void AddMovement(DateOnly movementDate, int transactionValue, int outputBalance);
}