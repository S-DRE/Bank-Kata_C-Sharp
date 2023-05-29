namespace Bank;

public class DateCreator
{

    public virtual DateTime CreateCurrentDate()
    {
        return DateTime.Now;
    }
}