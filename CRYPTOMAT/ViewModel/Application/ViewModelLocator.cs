using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRYPTOMAT
{
    /// <summary>
    /// Locates view model for xaml
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Siglenton instance of the locater
        /// </summary>
        public static ViewModelLocator Instance { get; private set; } = new ViewModelLocator();

        public static ApplicationViewModel ApplicationViewModel
        {
            get { return IoC.Application; }
        }

    }


    /// <summary>
    /// Locates view model for xaml
    /// </summary>
    public class TransactionViewModelLocator
    {
        /// <summary>
        /// Siglenton instance of the locater
        /// </summary>
        public static TransactionViewModelLocator Instance { get; private set; } = new TransactionViewModelLocator();

        public static TransactionViewModel Transaction
        {
            get { return IoC.Transaction; }
        }

    }
}
