using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRYPTOMAT
{
    public  class BuyCashLimitDisignViewModel : BuyCashLimitViewModel
    {
        public static BuyCashLimitDisignViewModel Instance { get; set; } = new BuyCashLimitDisignViewModel();

        public BuyCashLimitDisignViewModel()
        {
            Currency = IoC.CryptoCurrencyRepository.GetCryptoCurrencyById(1);
            Currency.ExchangeRate = 8000;
            PlanningToInsertEuro = 500;
            this.MenuViewModel.Initialize(this.GetType().BaseType);
        }
    }
}
