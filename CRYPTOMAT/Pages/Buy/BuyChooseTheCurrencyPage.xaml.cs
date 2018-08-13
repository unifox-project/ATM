using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CRYPTOMAT
{
    /// <summary>
    /// Interaction logic for BuyChooseTheCurrencyPage.xaml
    /// </summary>
    public partial class BuyChooseTheCurrencyPage 
    {
        /// <summary>
        /// Defaul constructor
        /// </summary>
        public BuyChooseTheCurrencyPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor with specific view model
        /// </summary>
        public BuyChooseTheCurrencyPage(BuyChooseTheCurrencyViewModel specificViewModel) : base(specificViewModel)
        {
            InitializeComponent();
        }
    }
}
