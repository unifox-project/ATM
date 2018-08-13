using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRYPTOMAT
{
    public  class BuyProcessingTransactionDesignViewModel : BuyProcessingTransactionViewModel
    {
        public static BuyProcessingTransactionDesignViewModel Instance { get; set; } = new BuyProcessingTransactionDesignViewModel();
        public BuyProcessingTransactionDesignViewModel()
        {
            Currency = IoC.CryptoCurrencyRepository.GetCryptoCurrencyById(1);
            Currency.ExchangeRate = 8000;
            this.InsertedEuro = 500;
            this.MenuViewModel.Initialize(this.GetType().BaseType);
            this.TransactionString = "12345678";
        }

        

    }
}
