using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CRYPTOMAT
{
    public class SellProcessingTransactionViewModel : SellBasePageViewModel
    {
           /// <summary>
        /// default constructor
        /// </summary>
        public SellProcessingTransactionViewModel()
        {
            Header.TextForTitle = "PROCESSING TRANSACTION COMPLETED";
            NextBtnEnabled = true;
            PrevPageCommand = new RelayCommand(async () => await GoPrevPageAsync());
            NextPageCommand = new RelayCommand(async () => await GoNextPageAsync());

            Currency = IoC.Transaction.Sell.Currency;
            TransactionString = IoC.Transaction.Sell.Id;
            PlanningCountToGetEuro = IoC.Transaction.Sell.PlanningCountToGetEuro;
            PlanningCountToSellCryptoCurrency = IoC.Transaction.Sell.PlanningCountToSellCryptoCurrency;
            OnlineWallet = IoC.Transaction.Sell.OnlineWallet;
            QrCodeImage = new BitmapImage(ResourceAccessor.Get(@"Resources\Images\sell_20180316115843.png"));
        }

        public BitmapImage QrCodeImage { get; set; }

        /// <summary>
        /// Current crypto Currency
        /// </summary>
        public CryptoCurrency Currency { get; set; }
        /// <summary>
        /// Quantity of EURO as a result of transaction
        /// </summary>
        public int PlanningCountToGetEuro { get; set; }
        /// <summary>
        /// The amount of cryptocurrency that will be sold out as a result of the transaction
        /// </summary>
        public double PlanningCountToSellCryptoCurrency { get; set; }
        /// <summary>
        /// Transaction Id
        /// </summary>
        public string TransactionString { get; set; }

        /// <summary>
        /// address of online wallet
        /// </summary>
        public string OnlineWallet { get; set; }

        /// <summary>
        /// Go to the next page
        /// </summary>
        /// <returns></returns>
        private async Task GoNextPageAsync()
        {
            await Task.Delay(1);
            IoC.Transaction.Clear();
            IoC.Application.GoToPage(ApplicationPage.MainPage);
        }
        /// <summary>
        /// Go to the previous page
        /// </summary>
        /// <returns></returns>
        private async Task GoPrevPageAsync()
        {
            await Task.Delay(1);
            IoC.Transaction.Clear();
            IoC.Application.GoToPage(ApplicationPage.MainPage);
        }
    }

}
