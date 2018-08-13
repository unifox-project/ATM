using System.Diagnostics;

namespace CRYPTOMAT
{
    /// <summary>
    /// Convert the <see cref="ApplicationPage"/> to actual view model
    /// </summary>
    public static class ApplicationPageHelpers
    {
        /// <summary>
        /// Tasks a <see cref="ApllicationPage"/> and a view model, any creates the desired page
        /// </summary>
        /// <typeparam name=""></typeparam>
        /// <param name="page"></param>
        /// <param name="viewModel"></param>
        /// <returns></returns>

        public static BasePage ToBasePage(this ApplicationPage page)
        {
            // Find the appropriate page
            switch (page)
            {
                case ApplicationPage.StartPage:
                    return new PageStart();

                case ApplicationPage.MainPage:
                    return new MainPage();

                #region buy section

                case ApplicationPage.BuyChooseTheCurrency:
                    return new BuyChooseTheCurrencyPage();
                case ApplicationPage.BuyDestinationAddress:
                    return new BuyDestinationAddressPage();
                case ApplicationPage.BuyCashLimit:
                    return  new BuyCashLimitPage();
                case ApplicationPage.BuyInsertCash:
                    return  new BuyInsertCashPage();
                case ApplicationPage.BuyProcessingTransaction:
                    return new BuyProcessingTransactionPage();

                #endregion



                #region sell section

                case ApplicationPage.SellChooseTheCurrency:
                    return  new SellChooseTheCurrencyPage();
                case ApplicationPage.SellCashLimit:
                    return new SellCashLimitPage();
                case ApplicationPage.SellEnterPhoneNumber:
                    return new SellEnterPhoneNumberPage();
                case ApplicationPage.SellProcessingTransaction:
                    return new SellProcessingTransactionPage();

                #endregion


                #region Redeem section

                case ApplicationPage.RedeemTicket:
                    return new RedeemTicketPage();
                case ApplicationPage.RedeemProcessingTransaction:
                    return new RedeemProcessingTransactionPage();

                #endregion



                default:
                    Debugger.Break();
                    return null;
            }
        }

        /// <summary>
        /// Converts a <see cref="BasePage"/> to the specific <see cref="ApplicationPage"/>
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public static ApplicationPage ToApplicationPage(this BasePage page)
        {
            // Find apllication page that matches the base page

            if (page is PageStart)
            {
                return ApplicationPage.StartPage;
            }
            if (page is MainPage)
            {
                return ApplicationPage.MainPage;
            }

            #region Buy section

            if (page is BuyChooseTheCurrencyPage)
            {
                return ApplicationPage.BuyChooseTheCurrency;
            }
            if (page is BuyDestinationAddressPage)
            {
                return ApplicationPage.BuyDestinationAddress;
            }
            if (page is BuyCashLimitPage)
            {
                return ApplicationPage.BuyCashLimit;
            }
            if (page is BuyInsertCashPage)
            {
                return ApplicationPage.BuyInsertCash;
            }
            if (page is BuyProcessingTransactionPage)
            {
                return ApplicationPage.BuyProcessingTransaction;
            }


   

            #endregion


            #region Buy section

            if (page is SellChooseTheCurrencyPage)
            {
                return ApplicationPage.SellChooseTheCurrency;
            }
            if (page is SellCashLimitPage)
            {
                return ApplicationPage.SellCashLimit;
            }
            if (page is SellEnterPhoneNumberPage)
            {
                return ApplicationPage.SellEnterPhoneNumber;
            }
            if (page is SellProcessingTransactionPage)
            {
                return ApplicationPage.SellProcessingTransaction;
            }


            #endregion

            #region Buy section

            if (page is RedeemTicketPage)
            {
                return ApplicationPage.RedeemTicket;
            }
            if (page is RedeemProcessingTransactionPage)
            {
                return ApplicationPage.RedeemProcessingTransaction;
            }
        
            #endregion

            Debugger.Break();
            return default(ApplicationPage);
        }
    }
}
