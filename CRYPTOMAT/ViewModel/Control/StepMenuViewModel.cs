using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Media;

namespace CRYPTOMAT
{
    public abstract class StepMenuViewModel:BaseViewModel
    {
        protected static Brush InActiveForeground { get { return MenuButtonViewModel.InActiveForeground; } }
        protected static Brush ActiveForeground { get { return MenuButtonViewModel.ActiveForeground; } }
        protected ImageSource EmptyMenuImage { get { return MenuButtonViewModel.EmptyMenuImage; } } // буду менять картинку 
        protected ImageSource CurrentMenuImage { get { return MenuButtonViewModel.CurrentMenuImage; } }
        protected ImageSource ValidMenuImage { get { return MenuButtonViewModel.ValidMenuImage; } }
        
        public string LabelTitleText { get; set; } = "4 steps to sell\nany сrypto-currency";
        public ObservableCollection<string> TextStrings { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<MenuButtonViewModel> Buttons { get; set; } = new ObservableCollection<MenuButtonViewModel>();

        protected StepMenuViewModel()
        {
            var s1 = "If you have some problems\nplease call to our support:\n";
            var s2 = "";
            var s3 = "+12 (123) 456 78 90";
            string[] texts = { s1, s2, s3 };
            SetTextStrings(texts);
        }

        public abstract void Initialize(Type ownerType);


        protected void SetTextStrings(IEnumerable<string> textStrings)
        {
            if (TextStrings.Any())
            {
                TextStrings.Clear();
            }
            foreach (var b in textStrings)
            {
                TextStrings.Add(b);
            }
        }

    }
}