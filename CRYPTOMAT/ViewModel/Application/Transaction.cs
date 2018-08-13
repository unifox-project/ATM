using NLog;

namespace CRYPTOMAT
{
    public class TransactionViewModel :BaseViewModel
    {
        public double Fee { get;  private set; } = 0.01;
        public int MaximumTransactionAmountInEuro { get; private set; } = 1000;

        public BuyTransaction Buy { get; private set; } = new BuyTransaction();
        public SellTransaction Sell { get; private set; } = new SellTransaction();
        public RedeemTransaction Redeem { get; private set; } = new RedeemTransaction();

        public void Clear()
        {
            Buy = new BuyTransaction();
            Sell = new SellTransaction();
            Redeem = new RedeemTransaction();
        }
    }
}