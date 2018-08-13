using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRYPTOMAT
{
   public  class SellProcessingTransactionDisignViewModel : SellProcessingTransactionViewModel
    {
        public static SellProcessingTransactionDisignViewModel Instance { get; set; } = new SellProcessingTransactionDisignViewModel();
        public SellProcessingTransactionDisignViewModel()
        {
            Currency = IoC.CryptoCurrencyRepository.GetCryptoCurrencyById(1);
            Currency.ExchangeRate = 8000;
            this.PlanningCountToGetEuro = 500;
            this.MenuViewModel.Initialize(this.GetType().BaseType);
            this.TransactionString = "12345678";
        }
    }
}
