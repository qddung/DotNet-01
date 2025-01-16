namespace WalletProj.Models.Components;
public enum TransactionType : int
{
    None = 0,
    Withdraw = 1,
    Deposit = 2
}

public class TransactionInfo
{
    public TransactionType TransactionType { get; set; } = TransactionType.None;
    public string TransactionName
    {
        get
        {
            if (TransactionType == TransactionType.None) return "";
            if (TransactionType == TransactionType.Withdraw) return "Withdraw";
            return "Deposit";
        }
    }

    public double Money { get; set; }

    public DateTime CreateDate { get; set; } = DateTime.Now;
}