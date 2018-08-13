namespace CRYPTOMAT
{
    public class SellTransaction : BaseViewModel
    {
        /// <summary>
        /// Id transaction on api
        /// </summary>
        public string Id { get; set; } = "12345678";
        public string QuittanceUrl { get; set; } = "";
        public string QrUrl { get; set; } = "";
        /// <summary>
        /// address  of online wallet
        /// </summary>
        public string OnlineWallet { get; set; } = "OX1234567890QWERTYUIOPASDFGHJKLZXCVBNM1234";
        /// <summary>
        /// Current crypto Currency
        /// </summary>
        public CryptoCurrency Currency { get; set; }
        public int PlanningCountToGetEuro { get; set; }
        public double PlanningCountToSellCryptoCurrency { get; set; }
        public string PhoneNumber { get; set; }
    }
}