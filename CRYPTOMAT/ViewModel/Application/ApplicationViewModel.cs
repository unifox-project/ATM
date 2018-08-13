using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRYPTOMAT
{
    /// <summary>
    /// The application state as a view model
    /// </summary>
    public class ApplicationViewModel : BaseViewModel
    {
        /// <summary>
        /// The current page of application
        /// </summary>
        public ApplicationPage CurrentPage { get;  private set; } = ApplicationPage.MainPage;
        
        /// <summary>
        /// Navigates to the specified page
        /// </summary>
        /// <param name="page">The page to go to</param>
        public void GoToPage(ApplicationPage page)
        {
            // See if page has changed
            var different = CurrentPage != page;
            if (different)
            {
                CurrentPage = page;
            }
        }
    }
}
