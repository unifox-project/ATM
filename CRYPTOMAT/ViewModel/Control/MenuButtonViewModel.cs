using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CRYPTOMAT
{
    public class MenuButtonViewModel:BaseViewModel
    {
        #region Resources

        private static Brush _inActiveForeground;
        private static Brush _activeForeground;
        private static ImageSource _validMenuImage;
        private static ImageSource _currentMenuImage;
        private static ImageSource _emptyMenuImage;

        private static Uri uriToEmptyMenuButton = ResourceAccessor.Get(@"Resources\Images\Menu\step_menubutton_empty.png");
        private static Uri uriToCurrentMenuButton = ResourceAccessor.Get(@"Resources\Images\Menu\step_menubutton_current.png");
        private static Uri uriToValidMenuButton = ResourceAccessor.Get(@"Resources\Images\Menu\step_menubutton_valid.png");

        public static Brush InActiveForeground
        {
            get
            {
                if (_inActiveForeground == null)
                {
                    _inActiveForeground = new SolidColorBrush(Color.FromRgb(47, 117, 193));
                }
                return _inActiveForeground;
            }
        }
        public static Brush ActiveForeground
        {
            get
            {
                if (_activeForeground == null)
                {
                    _activeForeground = new SolidColorBrush(Color.FromRgb(245, 144, 49));
                }
                return _activeForeground;
            }
        }
        public static Brush NotInitializeForeground { get { return Brushes.Gray; } }

        public static ImageSource EmptyMenuImage
        {
            get
            {
                if (_emptyMenuImage == null)
                {
                    _emptyMenuImage = new BitmapImage(uriToEmptyMenuButton);
                }



                return _emptyMenuImage;
            }
        } // буду менять картинку 

        public static ImageSource CurrentMenuImage
        {
            get
            {
                if (_currentMenuImage == null)
                {
                    _currentMenuImage = new BitmapImage(uriToCurrentMenuButton);
                }

                return _currentMenuImage;
            }
        }

        public static ImageSource ValidMenuImage
        {
            get
            {
                if (_validMenuImage == null)
                {
                    _validMenuImage = new BitmapImage(uriToValidMenuButton);

                }
                return _validMenuImage;
            }
        }

        #endregion

        public MenuButtonViewModel()
        {
            TextForeColor = NotInitializeForeground;
            ButtonBackgound = EmptyMenuImage;
        }
        public string ButtonName { get; set; }
        public string ButtonText { get; set; }
        public ImageSource ButtonBackgound { get; set; }
        public System.Windows.Media.Brush TextForeColor { get; set; }
    }

 






}
