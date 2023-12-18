namespace Bank;

public interface IMovement
{
    public DateOnly GetDate();
    public int GetTransactionValue();
    public int GetOutputBalance();
}