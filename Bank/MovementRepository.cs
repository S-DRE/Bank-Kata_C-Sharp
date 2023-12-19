﻿namespace Bank;

public class MovementRepository : IMovementRepository
{
    private readonly List<IMovement> movementsList = new();
    
    public List<IMovement> GetMovements()
    {
        return movementsList;
    }

    public void AddMovement(DateOnly movementDate, int transactionValue, int outputBalance)
    {
        throw new NotImplementedException();
    }
}