namespace CRYPTOMAT
{
    public enum ApplicationPage
    {
        /// <summary>
        /// Page where  take place initialize all device
        /// </summary>
        StartPage = 0,
        /// <summary>
        /// The  main page of application
        /// </summary>
        MainPage = 1,

        /// <summary>
        /// The first page of buying crypto currency
        /// </summary>
        BuyChooseTheCurrency = 11,

        /// <summary>
        /// The first page of buying crypto currency
        /// </summary>
        BuyDestinationAddress = 12,

        /// <summary>
        /// On the page, the user enters the amount of euro he want to deposit
        /// </summary>
        BuyCashLimit = 13,

        /// <summary>
        /// At this step, the user enters banknotes
        /// </summary>
        BuyInsertCash = 14,

        /// <summary>
        /// The final page of the section for purchasing crypto currency
        /// </summary>
        BuyProcessingTransaction = 15,

        /// <summary>
        /// The first page of sales of crypto currency
        /// </summary>
        SellChooseTheCurrency = 21,

        /// <summary>
        ///  On the page, the user enters the amount of euro he want to get
        /// </summary>
        SellCashLimit=22,

        /// <summary>
        ///On this page user enter his phone number
        /// </summary>
        SellEnterPhoneNumber = 23,

        /// <summary>
        /// The final page of the sell section
        /// </summary>
        SellProcessingTransaction = 24,

        /// <summary>
        ///  On the page, the user  scan qr code
        /// </summary>
        RedeemTicket = 31,
        /// <summary>
        ///  On the page, the user  gets banknotes
        /// </summary>
        RedeemProcessingTransaction = 32
    }
}
