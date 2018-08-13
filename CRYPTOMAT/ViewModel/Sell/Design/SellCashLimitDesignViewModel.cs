using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRYPTOMAT
{
   public  class SellCashLimitDesignViewModel : SellCashLimitViewModel
    {
        public static SellCashLimitDesignViewModel Instance { get; set; } = new SellCashLimitDesignViewModel();
        public SellCashLimitDesignViewModel()
        {
            Currency = IoC.CryptoCurrencyRepository.GetCryptoCurrencyById(1);
            Currency.ExchangeRate = 8000;
            PlanningCountToGetEuro = 500;
            this.MenuViewModel.Initialize(this.GetType().BaseType);
        }
    }
}
