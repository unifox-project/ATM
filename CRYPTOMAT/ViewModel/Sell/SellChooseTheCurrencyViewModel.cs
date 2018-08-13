using System;
using System.Threading.Tasks;

namespace CRYPTOMAT
{
    public class SellChooseTheCurrencyViewModel : SellBasePageViewModel
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public SellChooseTheCurrencyViewModel()
        {
            Header.TextForTitle = "CHOOSE THE CURRENCY";
            NextPageCommand = new RelayParameterizedCommand(async (parametr) => await GoNextPageAsync(parametr));
            PrevPageCommand = new RelayCommand(async () => await GoPrevPageAsync());
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
        /// <summary>
        /// Go to the next page
        /// </summary>
        /// <param name="parametr">Id selected currency</param>
        /// <returns></returns>
        private async Task GoNextPageAsync(object parametr)
        {
            await Task.Delay(1);
            try
            {
                CryptoCurrency selectedCurrency = IoC.CryptoCurrencyRepository.GetCryptoCurrencyById(int.Parse(parametr.ToString()));
                Log.Info("User selected currency {0}", selectedCurrency.Name);
                IoC.Transaction.Sell.Currency = selectedCurrency;
                IoC.Application.GoToPage(ApplicationPage.SellCashLimit);
            }
            catch (Exception e)
            {
                Log.Error(e, "unknown currency");
            }
        }
    }
}