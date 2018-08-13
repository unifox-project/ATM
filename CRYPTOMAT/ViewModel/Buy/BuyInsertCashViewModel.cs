using System.Threading.Tasks;

namespace CRYPTOMAT
{
    public class BuyInsertCashViewModel : BuyBasePageViewModel
    {
        /// <summary>
        /// flag shows the possibility of return to the previous page
        /// </summary>
        public bool UserCanGoBack { get; set; }
        /// <summary>
        /// default constructor
        /// </summary>
        public BuyInsertCashViewModel()
        {
            Header.TextForTitle = "INSERT CASH";
           
            UserCanGoBack = true;
            NextPageCommand = new RelayCommand(async () => await GoNextPageAsync());
            PrevPageCommand = new RelayCommand(async () => await GoPrevPageAsync());

            HaveToInsertEuro = IoC.Transaction.Buy.PlanningToInsertEuro;
            //TODO:  change InsertedEuro to 0
            InsertedEuro = IoC.Transaction.Buy.PlanningToInsertEuro;
            PlanningCountToBuyCurrency = IoC.Transaction.Buy.PlanningCountToBuyCurrency;
            Currency = IoC.Transaction.Buy.Currency;

            OnlineWallet =IoC.Transaction.Buy.OnlineWallet;

            NextBtnEnabled = true;
        }

        /// <summary>
        /// The amount of euro that the user have to enter into the terminal
        /// </summary>
        public int HaveToInsertEuro { get; set; }
        /// <summary>
        /// The amount of euros that the user has already deposited into the terminal
        /// </summary>
        public int InsertedEuro { get; set; }
        /// <summary>
        /// Current crypto Currency
        /// </summary>
        public CryptoCurrency Currency { get; set; }
        /// <summary>
        /// Amount of crypto currency to purchase
        /// </summary>
        public double PlanningCountToBuyCurrency { get; set; }

        /// <summary>
        /// address of online wallet
        /// </summary>
        public string  OnlineWallet { get; set; }


        /// <summary>
        /// Go to the previous page
        /// </summary>
        /// <returns></returns>
        private async Task GoPrevPageAsync()
        {
            await Task.Delay(1);
            IoC.Transaction.Buy.PlanningToInsertEuro=0;
            IoC.Transaction.Buy.PlanningCountToBuyCurrency=0;
            IoC.Application.GoToPage(ApplicationPage.BuyCashLimit);
        }
        /// <summary>
        /// Go to the next page
        /// </summary>
        /// <returns></returns>
        private async Task GoNextPageAsync()
        {
            await Task.Delay(1);
            IoC.Application.GoToPage(ApplicationPage.BuyProcessingTransaction);
        }
    }

}
