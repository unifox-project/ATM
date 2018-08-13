using System.Threading.Tasks;
using System.Windows.Input;

namespace CRYPTOMAT
{
    public class MainPageViewModel :BasePageViewModel
    {
        public ICommand СhoicePartCommand { get; private set; }
        public MainPageViewModel()
        {
            СhoicePartCommand = new RelayParameterizedCommand(async (parameter) => await СhoicePartAsync(parameter));
        }
        /// user click go to part .....
        private async Task СhoicePartAsync(object parameter)
        {
            await Task.Delay(1);

            string choice = parameter as string;
            if (choice == "1")
            {
                IoC.Application.GoToPage(ApplicationPage.BuyChooseTheCurrency);
            }
            else if (choice == "2")
            {
                IoC.Application.GoToPage(ApplicationPage.SellChooseTheCurrency);
            }
            else if (choice == "3")
            {
                IoC.Application.GoToPage(ApplicationPage.RedeemTicket);
            }

        }
    }

    public class PageStartViewModel : BasePageViewModel
    {
    }
}
