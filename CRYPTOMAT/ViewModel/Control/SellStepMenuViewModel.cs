using System;


namespace CRYPTOMAT
{
    public class SellStepMenuViewModel : StepMenuViewModel
    {

        public SellStepMenuViewModel()
        {
            if (IoC.Transaction.Sell.Currency != null)
            {
                Buttons.Add(
                    new MenuButtonViewModel()
                        { ButtonName = "MenuBtn1", ButtonText = "Choosen currency: " + IoC.Transaction.Sell.Currency.Name });
            }
            else
            {
                Buttons.Add(new MenuButtonViewModel() { ButtonName = "MenuBtn1", ButtonText = "Choose the currency:" });
            }

            if (IoC.Transaction.Sell.PlanningCountToGetEuro == 0)
            {
                Buttons.Add(new MenuButtonViewModel() { ButtonName = "MenuBtn2", ButtonText = "Cash Limit:" });
            }
            else
            {
                Buttons.Add(new MenuButtonViewModel()
                {
                    ButtonName = "MenuBtn2",
                    ButtonText = "Cash Limit: " + IoC.Transaction.Sell.PlanningCountToGetEuro + " €"
                });
            }

            Buttons.Add(new MenuButtonViewModel() { ButtonName = "MenuBtn3", ButtonText = "Phone number" });
            Buttons.Add(new MenuButtonViewModel() { ButtonName = "MenuBtn4", ButtonText = "Redeem ticket" });
            IoC.Transaction.PropertyChanged += Transaction_PropertyChanged;
        }

        private void Transaction_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
           
        }

        public override void Initialize(Type ownerType)
        {
            if (ownerType == typeof(SellChooseTheCurrencyViewModel))
            {
                foreach (var btnStep in Buttons)
                {
                    if (btnStep.ButtonName == "MenuBtn1")
                    {
                        btnStep.TextForeColor = ActiveForeground;
                        btnStep.ButtonBackgound = CurrentMenuImage;
                    }
                }
            }
            else if (ownerType == typeof(SellCashLimitViewModel))
            {

                foreach (var btnStep in Buttons)
                {
                    if (btnStep.ButtonName == "MenuBtn1")
                    {
                        btnStep.ButtonBackgound = ValidMenuImage;
                        btnStep.TextForeColor = InActiveForeground;
                    }
                    else if (btnStep.ButtonName == "MenuBtn2")
                    {
                        btnStep.TextForeColor = ActiveForeground;
                        btnStep.ButtonBackgound = CurrentMenuImage;
                    }
                }
            }
            else if (ownerType == typeof(SellEnterPhoneNumberViewModel))
            {
                foreach (var btnStep in Buttons)
                {
                    if (btnStep.ButtonName == "MenuBtn1" || btnStep.ButtonName == "MenuBtn2")
                    {
                        btnStep.ButtonBackgound = ValidMenuImage;
                        btnStep.TextForeColor = InActiveForeground;
                    }
                    else if (btnStep.ButtonName == "MenuBtn3")
                    {
                        btnStep.TextForeColor = ActiveForeground;
                        btnStep.ButtonBackgound = CurrentMenuImage;
                    }
                }
            }
            else if (ownerType == typeof(SellProcessingTransactionViewModel))
            {
                foreach (var btnStep in Buttons)
                {
                    if (btnStep.ButtonName == "MenuBtn1" || btnStep.ButtonName == "MenuBtn2" || btnStep.ButtonName == "MenuBtn3")
                    {
                        btnStep.ButtonBackgound = ValidMenuImage;
                        btnStep.TextForeColor = InActiveForeground;
                    }
                    else if (btnStep.ButtonName == "MenuBtn4")
                    {
                        btnStep.TextForeColor = ActiveForeground;
                        btnStep.ButtonBackgound = CurrentMenuImage;
                    }
                }
            }
        }
    }
}
