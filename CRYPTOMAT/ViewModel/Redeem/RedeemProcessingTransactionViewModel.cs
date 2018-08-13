using System.Threading.Tasks;

namespace CRYPTOMAT
{
    public class RedeemProcessingTransactionViewModel :RedeemBasePageViewModel
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public RedeemProcessingTransactionViewModel()
        {
            Header.TextForTitle = "PROCESSING TRANSACTION COMPLETED";
            TransactionString = IoC.Transaction.Redeem.Id;
            OutputMoney = IoC.Transaction.Redeem.CountEuro;
            NextPageCommand = new RelayCommand(async () => await GoNextPageAsync());
            Task.Run(async ()=> 
            {
                try
                {
                    IsRunning = true;
                    await Task.Delay(2000);
                }
                finally
                {
                    IsRunning = false;
                }
            });

        }

        public int OutputMoney { get; set; }
        public string TransactionString { get; set; }
        /// <summary>
        /// Go to the next page`
        /// </summary>
        /// <returns></returns>
        private async Task GoNextPageAsync()
        {
            await Task.Delay(1);
            IoC.Transaction.Clear();
            IoC.Application.GoToPage(ApplicationPage.MainPage);
        }

    }
}
