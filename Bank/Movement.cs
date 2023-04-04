namespace Bank;

public class Movement
{
    public Movement(DateTime date, int operationAmount, int remainingBalance)
    {
        this.date = date;
        this.operationAmount = operationAmount;
        this.remainingBalance = remainingBalance;
    }

    public DateTime date {get; }
    public int operationAmount {get; }
    public int remainingBalance {get; }
}