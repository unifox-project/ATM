namespace CRYPTOMAT
{
    public class BuyTransaction : BaseViewModel
    {
        /// <summary>
        /// Id transaction on api
        /// </summary>
        public string Id { get; set; } = "12345678";
        public string QuittanceUrl { get; set; } = "";
        /// <summary>
        /// Current crypto Currency
        /// </summary>
        public CryptoCurrency Currency { get; set; }
        /// <summary>
        /// The amount of euro that the user have to enter into the terminal
        /// </summary>
        public int PlanningToInsertEuro { get; set; } = 0;
        /// <summary>
        /// Amount of crypto currency to purchase
        /// </summary>
        public double PlanningCountToBuyCurrency { get; set; } = 0;
        /// <summary>
        /// address  of online wallet
        /// </summary>
        public string OnlineWallet { get; set; } = "OX1234567890QWERTYUIOPASDFGHJKLZXCVBNM1234";

    }
}