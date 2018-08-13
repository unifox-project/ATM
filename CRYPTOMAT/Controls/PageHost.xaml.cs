using System.Windows;
using System.Windows.Controls;

namespace CRYPTOMAT
{
    /// <summary>
    /// Interaction logic for PageHost.xaml
    /// </summary>
    public partial class PageHost : UserControl
    {
        public PageHost()
        {
            InitializeComponent();
        }


        #region Dependency properties

        /// <summary>
        /// The current page to show in the page host
        /// </summary>
        public ApplicationPage CurrentPage
        {
            get { return (ApplicationPage)GetValue(CurrentPageProperty); }
            set { SetValue(CurrentPageProperty, value); }
        }

        /// <summary>
        /// Registers <see cref="CurrentPage"/> as a dependency property
        /// </summary>
        public static readonly DependencyProperty CurrentPageProperty = DependencyProperty.Register(nameof(CurrentPage),
            typeof(ApplicationPage), typeof(PageHost), new UIPropertyMetadata(default(ApplicationPage), null, CurrentPagePropertyChanged));





        #endregion


        #region Property change events
        /// <summary>
        /// Called when the <see cref="CurrentPage"/> value has changed
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static object CurrentPagePropertyChanged(DependencyObject d, object value)
        {
            var host = d as PageHost;
            if (host == null)
                return value;

            //Get current value  
            var currentPage = (ApplicationPage)value;
           var newPageFrame = host.PageContent;


            BasePage oldPage = null;

            if (newPageFrame.Content is BasePage)
            {
                var page = (BasePage)newPageFrame.Content;

                if (page.ToApplicationPage() == currentPage)
                {
                    return value;
                }
                oldPage = (BasePage)newPageFrame.Content;
            }
           // ChangePage(newPageFrame, currentPage, currentPageViewModel, oldPage);
            host.Content = currentPage.ToBasePage();//newPage.ToBasePage(newViewMode);
            return value;
        }

        //private static async void ChangePage(ContentControl host, ApplicationPage newPage, object newViewMode = null, BasePage oldPage = null)
        //{
        //    //if (oldPage != null)
        //    //{
        //    //    await oldPage.FadeOutAsync();
        //    //}

        //    host.Content = newPage.ToBasePage(newViewMode);

        //}

        #endregion


    }
}
