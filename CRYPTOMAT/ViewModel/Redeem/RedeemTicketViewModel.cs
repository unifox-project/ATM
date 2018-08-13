using System.Threading.Tasks;

namespace CRYPTOMAT
{
    public class RedeemTicketViewModel : RedeemBasePageViewModel
    {
        public string ErrorMessage { get; set; }
        /// <summary>
        /// default constructor
        /// </summary>
        public RedeemTicketViewModel()
        {
            Header.TextForTitle = "REDEEM TICKET";
            NextPageCommand = new RelayCommand(async () => await GoNextPageAsync());
        }
        
        /// <summary>
        /// Go to the next page`
        /// </summary>
        /// <returns></returns>
        private async Task GoNextPageAsync()
        {
            await Task.Delay(1);
            IoC.Application.GoToPage(ApplicationPage.RedeemProcessingTransaction);
        }
    }
}