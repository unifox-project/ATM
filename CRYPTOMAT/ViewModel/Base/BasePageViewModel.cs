using System;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace CRYPTOMAT
{
    public class BasePageViewModel : BaseViewModel
    {
        public readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// a flag indicating if a command or some process  is running
        /// </summary>
        public bool IsRunning { get; set; }
        /// <summary>
        /// default constructor
        /// </summary>
        public BasePageViewModel()
        {
            MainPageCommand = new RelayCommand(async ()=> await GoMainPageAsync());
            Header = new HeaderAreaViewModel();
        }
        /// <summary>
        /// function break the step and show  main page 
        /// </summary>
        private async Task GoMainPageAsync()
        {
            await Task.Delay(1);
            IoC.Transaction.Clear();
            IoC.Application.GoToPage(ApplicationPage.MainPage);
        }

        /// <summary>
        /// ViewModel for  header control
        /// </summary>
        public HeaderAreaViewModel Header { get; set; }


        /// <summary>
        /// ViewModel for left menu
        /// </summary>
        public StepMenuViewModel MenuViewModel { get; set; }
        /// <summary>
        /// Command for go to previous page
        /// </summary>
        public ICommand PrevPageCommand { get; set; }
        /// <summary>
        /// Command for go to main page
        /// </summary>
        public ICommand MainPageCommand { get; set; }
        /// <summary>
        /// Command for go to next page
        /// </summary>
        public ICommand NextPageCommand { get; set; }

        /// <summary>
        /// a flag indicating avalible of next btn
        /// </summary>
        public bool NextBtnEnabled { get; set; }


    }

    public class HeaderAreaViewModel : BaseViewModel
    {
        private DispatcherTimer _dispatcherTimer;

        public HeaderAreaViewModel()
        {
            BtcExchangeRate = IoC.CryptoCurrencyRepository.GetCryptoCurrencyById(1).ToString();
            EthExchangeRate = IoC.CryptoCurrencyRepository.GetCryptoCurrencyById(2).ToString();
            DashExchangeRate = IoC.CryptoCurrencyRepository.GetCryptoCurrencyById(3).ToString();
            UnicashExchangeRate = IoC.CryptoCurrencyRepository.GetCryptoCurrencyById(6).ToString();

            _dispatcherTimer = new DispatcherTimer();
            _dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 1);
            UpdateDateTime();
            _dispatcherTimer.Tick += _dispatcherTimer_Tick;
        }

        public string UnicashExchangeRate { get; set; }

        public string DashExchangeRate { get; set; }

        public string EthExchangeRate { get; set; }

        public string BtcExchangeRate { get; set; }

        private void _dispatcherTimer_Tick(object sender, EventArgs e)
        {
            UpdateDateTime();
        }

        private void UpdateDateTime()
        {
            TimeString = DateTime.Now.ToString("s").Substring(11, 5);

            string day = DateTime.Now.Day.ToString();
            string month = mounts[DateTime.Now.Month];
            string year = DateTime.Now.Year.ToString();

            if (DateStringMainPage != day + " " + month + " " + year)
                DateStringMainPage = day + " " + month + " " + year;

            if (DateString != day + " " + month)
                DateString = day + " " + month;

            string dayOfWeek = "";
            dayOfWeek = days[(int)DateTime.Now.DayOfWeek];
            if (WeekDayString != dayOfWeek)
            {
                WeekDayString = dayOfWeek;
            }
        }

        public string TextForTitle { get; set; }
        public string DateStringMainPage { get; set; }
        public string DateString { get; set; }
        public string WeekDayString { get; set; }
        public string TimeString { get; set; }


        public void StartTimer()
        {

        }
        public void StopTimer()
        {

        }



        private static string[] mounts =
        {
            "",
            "Januára",
            "Februára",
            "Marca",
            "Apríla",
            "Mája",
            "Júna",
            "Júla",
            "Augusta",
            "Septembra",
            "Októbra",
            "Novembra",
            "Decembra"
        };

        private static string[] days =
        {
            "pondelok",
            "utorok",
            "streda",
            "štvrtok",
            "piatok",
            "sobota",
            "nedeľa"
        };


    }

}