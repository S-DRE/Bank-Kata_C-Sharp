namespace Bank;

public class Movement : IMovement
{
    private readonly DateOnly date;
    private readonly int transactionValue;
    private readonly int outputBalance;

    public Movement(DateOnly date, int transactionValue, int outputBalance)
    {
        this.date = date;
        this.transactionValue = transactionValue;
        this.outputBalance = outputBalance;
    }

    public DateOnly GetDate()
    {
        return date;
    }

    public int GetTransactionValue()
    {
        return transactionValue;
    }

    public int GetOutputBalance()
    {
        return outputBalance;
    }
}