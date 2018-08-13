using System.Threading.Tasks;

namespace CRYPTOMAT
{
    public class BuyDestinationAddressViewModel : BuyBasePageViewModel
    {
        /// <summary>
        /// Error message will be display on screen
        /// </summary>
        public string ErrorMessage { get; set; }
        /// <summary>
        /// default constructor
        /// </summary>
        public BuyDestinationAddressViewModel()
        {
            Header.TextForTitle = "DESTINATION ADDRESS";
            NextBtnEnabled = true;
            NextPageCommand = new RelayCommand(async () => await GoNextPageAsync());
            PrevPageCommand = new RelayCommand(async () => await GoPrevPageAsync());

        }
        /// <summary>
        /// Go to the previous page
        /// </summary>
        /// <returns></returns>
        public async Task GoPrevPageAsync()
        {
            await Task.Delay(1);
            IoC.Application.GoToPage(ApplicationPage.BuyChooseTheCurrency);
        }
        /// <summary>
        /// Go to the next page
        /// </summary>
        private async Task GoNextPageAsync()
        {
            await Task.Delay(1);
            IoC.Application.GoToPage(ApplicationPage.BuyCashLimit);
        }
    }
}
