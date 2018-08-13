using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CRYPTOMAT
{
    public class SellEnterPhoneNumberViewModel : SellBasePageViewModel
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public SellEnterPhoneNumberViewModel()
        {
            Header.TextForTitle = "PHONE NUMBER";
            DigitButtonPressCommand = new RelayParameterizedCommand(async (parametr) => await EnterDigitAsync(parametr));
            PrevPageCommand = new RelayCommand(async () => await GoPrevPageAsync());
            NextPageCommand = new RelayCommand(async () => await GoNextPageAsync());
            InputPhoneNumber = defaultMask;
        }

        private const string defaultMask = "0 *** - *** - ***";
        /// <summary>
        /// Click command on the virtual keyboard
        /// </summary>
        public ICommand DigitButtonPressCommand { get; set; }


        #region InputPhoneNumber

        private string _inputPhoneNumber = "";
        public string InputPhoneNumber
        {
            get { return _inputPhoneNumber; }
            set
            {
                _inputPhoneNumber = value;

                if (_inputPhoneNumber.Contains("*"))
                {
                    NextBtnEnabled = false;
                }
                else
                {
                    NextBtnEnabled = true;
                }

                OnPropertyChanged();
            }
        }

        #endregion


        /// <summary>
        /// Go to the next page
        /// </summary>
        /// <returns></returns>
        private async Task GoNextPageAsync()
        {
            await Task.Delay(1);
            IoC.Application.GoToPage(ApplicationPage.SellProcessingTransaction);
        }
        /// <summary>
        /// Go to the previous page
        /// </summary>
        /// <returns></returns>
        private async Task GoPrevPageAsync()
        {
            await Task.Delay(1);
            IoC.Transaction.Sell.PlanningCountToGetEuro = 0;
            IoC.Transaction.Sell.PlanningCountToSellCryptoCurrency = 0;
            IoC.Application.GoToPage(ApplicationPage.SellCashLimit);
        }
        /// <summary>
        /// Click event on the virtual keyboard
        /// </summary>
        /// <param name="parametr">can take on values {1,2,3,4,5,6,7,8,9,C, <![CDATA[<]]>}</param>
        /// <returns></returns>
        private async Task EnterDigitAsync(object parametr)
        {
            await Task.Delay(1);

            var command = parametr.ToString();
            if (string.IsNullOrEmpty(command)) return;

            //RestartHeaderTimer();

            if (command == "<")
            {
                if (InputPhoneNumber == defaultMask) return;
                var s = InputPhoneNumber;
                var index = -1;
                for (var i = s.Length - 1; i > 0; i--)
                {
                    var t = s[i];
                    if (char.IsDigit(t))
                    {
                        index = i;
                        break;
                    }
                }
                if (index != -1)
                {
                    var builder = new StringBuilder(InputPhoneNumber);
                    builder[index] = '*';
                    InputPhoneNumber = builder.ToString();
                }
                return;
            }
            if (command == "C")
            {
                //clean entered phoneNumber
                InputPhoneNumber = defaultMask;
                return;
            }
            // no one digit neaded
            if (!InputPhoneNumber.Contains("*"))
            {
                return;
            }

            var regex = new Regex(Regex.Escape("*"));
            InputPhoneNumber = regex.Replace(InputPhoneNumber, command, 1);
        }
    }
}