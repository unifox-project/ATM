using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CRYPTOMAT
{
    public class BuyCashLimitViewModel :BuyBasePageViewModel
    {
        private int _planningToInsertEuro = 0;

        /// <summary>
        /// default constructor
        /// </summary>
        public BuyCashLimitViewModel()
        {
            Header.TextForTitle = "CASH LIMIT";
            Currency = IoC.Transaction.Buy.Currency;
            DigitButtonPressCommand = new RelayParameterizedCommand(async (parameter) => await EnterDigitAsync(parameter));
            PrevPageCommand = new RelayCommand(async () => await GoPrevPageAsync());
            NextPageCommand = new RelayCommand(async () => await GoNextPageAsync());
        }
        /// <summary>
        /// Click command on the virtual keyboard
        /// </summary>
        public ICommand DigitButtonPressCommand { get; set; }
        public CryptoCurrency Currency { get; set; }
        /// <summary>
        /// The amount of euro for which the purchase of crypto currency will be made
        /// </summary>
        public int PlanningToInsertEuro
        {
            get => _planningToInsertEuro;
            set
            {
                _planningToInsertEuro = value;

                if (_planningToInsertEuro < 0)
                    _planningToInsertEuro = 0;

                if (_planningToInsertEuro > 0)
                {
                    NextBtnEnabled = true;
                }
                else
                {
                    NextBtnEnabled = false;
                }

                if (Currency != null)
                {
                    if (_planningToInsertEuro == 0)
                    {
                        PlanningCountToBuyCurrency = 0;
                    }
                    else
                    {
                        //TODO: Add check critical error if currency == 0 or Currency.ExchangeRate== 0;

                        PlanningCountToBuyCurrency = Math.Round(
                            (_planningToInsertEuro - _planningToInsertEuro * IoC.Transaction.Fee) 
                            / Currency.ExchangeRate, 8);
                    }
                }


                OnPropertyChanged();
            }
        }
        /// <summary>
        /// The amount of crypto currency that will be purchased as a result of the transaction
        /// </summary>
        public double PlanningCountToBuyCurrency { get; set; } = 0;

        /// <summary>
        /// Go to the next page
        /// </summary>
        /// <returns></returns>
        private async Task GoNextPageAsync()
        {
            await Task.Delay(1);
            IoC.Transaction.Buy.PlanningToInsertEuro = PlanningToInsertEuro;
            IoC.Transaction.Buy.PlanningCountToBuyCurrency = PlanningCountToBuyCurrency;
            IoC.Application.GoToPage(ApplicationPage.BuyInsertCash);
        }
        /// <summary>
        /// Go to the previous page
        /// </summary>
        /// <returns></returns>
        private async Task GoPrevPageAsync()
        {
            await Task.Delay(1);
            IoC.Transaction.Buy.PlanningToInsertEuro = 0;
            IoC.Transaction.Buy.PlanningCountToBuyCurrency = 0;
            IoC.Application.GoToPage(ApplicationPage.BuyDestinationAddress);
        }
        /// <summary>
        /// Click event on the virtual keyboard
        /// </summary>
        /// <param name="parameter">can take on values {1,2,3,4,5,6,7,8,9,C, <![CDATA[<]]>}</param>
        /// <returns></returns>
        private async Task EnterDigitAsync(object parameter)
        {
            Log.Debug("User enter on keyboard "+ parameter);

            await Task.Delay(1);
            var command = parameter.ToString();
            if (string.IsNullOrEmpty(command)) return;

            if (command == "<")
            {
                if (PlanningToInsertEuro >= 10)
                {
                    PlanningToInsertEuro = PlanningToInsertEuro / 10;
                }
                else
                {
                    PlanningToInsertEuro = 0;
                }
            }
            else if (command == "C")
            {
                PlanningToInsertEuro = 0;
            }
            else
            {
                int val = 0;
                if (int.TryParse(command, out val))
                {
                    if (PlanningToInsertEuro == 0)
                    {
                        PlanningToInsertEuro = val;
                    }
                    else
                    {
                        if (PlanningToInsertEuro * 10 + val <= IoC.Transaction.MaximumTransactionAmountInEuro)
                        {
                            PlanningToInsertEuro = PlanningToInsertEuro * 10 + val;
                        }
                        else
                        {
                            Log.Info("The maximum amount of this transaction was reached");
                        }
                    }
                }
                else
                {
                    Log.Info("unknown character "+ parameter);
                }
            }


        }
    }
}
