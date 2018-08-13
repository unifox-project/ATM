using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CRYPTOMAT
{
    public class SellCashLimitViewModel :SellBasePageViewModel
    {
        private int _planningCountToGetEuro;

        /// <summary>
        /// default constructor
        /// </summary>
        public SellCashLimitViewModel()
        {
            Header.TextForTitle = "CASH LIMIT";
            DigitButtonPressCommand = new RelayParameterizedCommand(async (parameter) => await EnterDigitAsync(parameter));
            NextPageCommand = new RelayCommand(async () => await GoNextPageAsync());
            PrevPageCommand = new RelayCommand(async () => await GoPrevPageAsync());


            PlanningCountToGetEuro = 0;
            PlanningCountToSellCurrency = 0;
            Currency = IoC.Transaction.Sell.Currency;

        }

        /// <summary>
        /// Current currency
        /// </summary>
        public CryptoCurrency Currency { get; set; }
        /// <summary>
        /// Quantity of EURO as a result of transaction
        /// </summary>
        public int PlanningCountToGetEuro       
        {
            get => _planningCountToGetEuro;
            set
            {
                _planningCountToGetEuro = value;
                if (_planningCountToGetEuro < 0)
                {
                    _planningCountToGetEuro = 0;
                }

                if (_planningCountToGetEuro >= 5)
                {
                    NextBtnEnabled = true;
                }
                else
                {
                    NextBtnEnabled = false;
                }

                if (Currency != null)
                {
                    if (_planningCountToGetEuro == 0)
                    {
                        PlanningCountToSellCurrency = 0;
                    }
                    else
                    {
                        //TODO: Add check critical error if currency == 0 or Currency.ExchangeRate== 0;
                        // transfer Euro to crypto currency
                        var v1 = Math.Round((double)(PlanningCountToGetEuro) / Currency.ExchangeRate, 8);
                        // minus our extra charge
                        PlanningCountToSellCurrency = Math.Round(v1 + v1 * IoC.Transaction.Fee, 8);
                    }
                }
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// The amount of cryptocurrency that will be sold out as a result of the transaction
        /// </summary>
        public double PlanningCountToSellCurrency { get; set; } = 0;

        /// <summary>
        /// Click command on the virtual keyboard
        /// </summary>
        public ICommand DigitButtonPressCommand { get; set; }
        
        /// <summary>
        /// Go to the previous page
        /// </summary>
        /// <returns></returns>
        private async Task GoPrevPageAsync()
        {
            await Task.Delay(1);

            PlanningCountToGetEuro = 0;
            PlanningCountToSellCurrency = 0;
            IoC.Application.GoToPage(ApplicationPage.SellChooseTheCurrency);
        }
        /// <summary>
        /// Go to the next page
        /// </summary>
        private async Task GoNextPageAsync()
        {
            await Task.Delay(1);

            IoC.Transaction.Sell.PlanningCountToGetEuro = PlanningCountToGetEuro;
            IoC.Transaction.Sell.PlanningCountToSellCryptoCurrency = PlanningCountToSellCurrency;
            IoC.Application.GoToPage(ApplicationPage.SellEnterPhoneNumber);
        }
        /// <summary>
        /// Click event on the virtual keyboard
        /// </summary>
        /// <param name="parameter">can take on values {1,2,3,4,5,6,7,8,9,C, <![CDATA[<]]>}</param>
        /// <returns></returns>
        private async Task EnterDigitAsync(object parameter)
        {
            await Task.Delay(1);

            Log.Debug("User enter on keyboard " + parameter);

            await Task.Delay(1);
            var command = parameter.ToString();
            if (string.IsNullOrEmpty(command)) return;

            if (command == "<")
            {
                if (PlanningCountToGetEuro >= 10)
                {
                    PlanningCountToGetEuro = PlanningCountToGetEuro / 10;
                }
                else
                {
                    PlanningCountToGetEuro = 0;
                }
            }
            else if (command == "C")
            {
                PlanningCountToGetEuro = 0;
            }
            else
            {
                int val = 0;
                if (int.TryParse(command, out val))
                {
                    if (PlanningCountToGetEuro == 0)
                    {
                        PlanningCountToGetEuro = val;
                    }
                    else
                    {
                        if (PlanningCountToGetEuro * 10 + val <= IoC.Transaction.MaximumTransactionAmountInEuro)
                        {
                            PlanningCountToGetEuro = PlanningCountToGetEuro * 10 + val;
                        }
                        else
                        {
                            Log.Info("The maximum amount of this transaction was reached");
                        }
                    }
                }
                else
                {
                    Log.Info("unknown character " + parameter);
                }
            }
        }
    }
}