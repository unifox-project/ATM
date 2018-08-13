using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRYPTOMAT
{
    public class BuyBasePageViewModel : BasePageViewModel
    {
        public BuyBasePageViewModel()
        {
            this.MenuViewModel = new BuyStepMenuViewModel();
            this.MenuViewModel.Initialize(this.GetType());
        }
    }
}
