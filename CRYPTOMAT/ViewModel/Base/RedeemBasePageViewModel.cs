namespace CRYPTOMAT
{
    public class RedeemBasePageViewModel : BasePageViewModel
    {
        public RedeemBasePageViewModel()
        {
            this.MenuViewModel = new RedeemStepMenuViewModel();
            this.MenuViewModel.Initialize(this.GetType());
        }
    }
}