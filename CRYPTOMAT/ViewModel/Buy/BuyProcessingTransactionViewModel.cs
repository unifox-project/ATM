using System.Threading.Tasks;

namespace CRYPTOMAT
{
    public class BuyProcessingTransactionViewModel:BuyBasePageViewModel
    {
        /// <summary>
        /// default ctor
        /// </summary>
        public BuyProcessingTransactionViewModel()
        {
            Header.TextForTitle = "PROCESSING TRANSACTION COMPLETED";
            InsertedEuro = IoC.Transaction.Buy.PlanningToInsertEuro;
            PlanningCountToBuyCurrency = IoC.Transaction.Buy.PlanningCountToBuyCurrency;
            Currency = IoC.Transaction.Buy.Currency;
            TransactionString = IoC.Transaction.Buy.Id;
            NextBtnEnabled = true;
            PrevPageCommand = new RelayCommand(async () => await GoPrevPageAsync());
            NextPageCommand = new RelayCommand(async () => await GoNextPageAsync());
        }

        private async Task GoNextPageAsync()
        {
            await Task.Delay(1);
            IoC.Transaction.Clear();
            IoC.Application.GoToPage(ApplicationPage.MainPage);
        }

        private async Task GoPrevPageAsync()
        {
            await Task.Delay(1);
        }

        /// <summary>
        /// Current crypto Currency
        /// </summary>
        public CryptoCurrency Currency { get; set; }

        /// <summary>
        /// The amount of euros that the user has already deposited into the terminal
        /// </summary>
        public int InsertedEuro { get; set; }

        /// <summary>
        /// Amount of crypto currency to purchase
        /// </summary>
        public double PlanningCountToBuyCurrency { get; set; }

        /// <summary>
        /// Transaction Id
        /// </summary>
        public string TransactionString { get; set; }


    }
}
