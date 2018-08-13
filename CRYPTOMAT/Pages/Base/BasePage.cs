using System.Windows.Controls;

namespace CRYPTOMAT
{
    public class BasePage : UserControl
    {
        /// <summary>
        /// The view model associated this page
        /// </summary>
        private object mViewModel;

        public object ViewModelObject   
        {
            get => mViewModel;
            set
            {
                if (mViewModel == value)
                    return;
                // Update the value
                mViewModel = value;
                // set data context for this page
                this.DataContext = mViewModel;
            }
        }
    }

    public class BasePage<VM> : BasePage where VM : BasePageViewModel, new()
    {
        /// <summary>
        /// The  view model
        /// </summary>
        public VM ViewModel
        {
            get { return (VM)ViewModelObject; }
            set { ViewModelObject = value; }
        }

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public BasePage() : base()
        {
            // Create default view model
            ViewModel = IoC.Get<VM>();
        }

        /// <summary>
        /// Constructor spesific view model param
        /// </summary>
        ///<param name="specificviewModel">The specific view model, to use if  any</param>
        public BasePage(VM specificviewModel = null) : base()
        {
            // Set specific view model
            if (specificviewModel != null)
            {
                ViewModel = specificviewModel;
            }
            else
                ViewModel = IoC.Get<VM>();

        }

        #endregion

    }




}
