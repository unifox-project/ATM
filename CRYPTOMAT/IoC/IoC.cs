using Ninject;

namespace CRYPTOMAT
{
    /// <summary>
    /// Ios container for the apllication
    /// </summary>
    public static class IoC
    {
        /// <summary>
        /// The kernel to IoC container
        /// </summary>
        public static IKernel Kernel { get; private set; } = new StandardKernel();
        /// <summary>
        /// A shortcut to acces the <see cref="ApplicationViewModel"/>
        /// </summary>
        public static ApplicationViewModel Application => Get<ApplicationViewModel>();
        /// <summary>
        /// A shortcut to acces the <see cref="ApplicationViewModel"/>
        /// </summary>
        public static TransactionViewModel Transaction => Get<TransactionViewModel>();

        public static CryptoCurrencyRepository CryptoCurrencyRepository => Get<CryptoCurrencyRepository>();


        /// <summary>
        /// Get's service from IoC
        /// </summary>
        /// <typeparam name="T"> The type to get</typeparam>
        /// <returns></returns>
        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }

        /// <summary>
        /// Set Ios conteiner, binds all information requred and is ready for use
        /// Note:Must be called as soon as the application start up
        /// </summary>
        public static void Setup()
        {
            //// load settings from settings.ini 
            //TerminalSettingsLocator.Load();
            // Bind All requred view models
            BindViewModels();

        }

        private static void BindViewModels()
        {
            //Kernel.Bind<ApplicationViewModel>().ToSelf().InSingletonScope();
            // bind to single instance of application view model
            Kernel.Bind<ApplicationViewModel>().ToConstant(new ApplicationViewModel());
            Kernel.Bind<TransactionViewModel>().ToConstant(new TransactionViewModel());
            Kernel.Bind<CryptoCurrencyRepository>().ToConstant(new CryptoCurrencyRepository());

            //Kernel.Bind<IConfigProvider>().ToConstant(new SettingsConfigProvider());
        }



    }
    }
