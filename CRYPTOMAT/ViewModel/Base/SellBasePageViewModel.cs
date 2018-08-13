namespace CRYPTOMAT
{
    public class SellBasePageViewModel : BasePageViewModel
    {
        public SellBasePageViewModel()
        {
            this.MenuViewModel = new SellStepMenuViewModel();
            this.MenuViewModel.Initialize(this.GetType());
        }
    }
}