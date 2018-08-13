using System;

namespace CRYPTOMAT
{
    public class BuyStepMenuViewModel : StepMenuViewModel
    {
        public BuyStepMenuViewModel()
        {

            if (IoC.Transaction.Buy.Currency != null)
            {
                Buttons.Add(
                    new MenuButtonViewModel()
                        { ButtonName = "MenuBtn1", ButtonText = "Choosen currency: " + IoC.Transaction.Buy.Currency.Name });
            }
            else
            {
                Buttons.Add(new MenuButtonViewModel() { ButtonName = "MenuBtn1", ButtonText = "Choose the currency:" });
            }
            Buttons.Add(new MenuButtonViewModel() { ButtonName = "MenuBtn2", ButtonText = "Enter destination address" });

            if (IoC.Transaction.Buy.PlanningToInsertEuro == 0)
            {
                Buttons.Add(new MenuButtonViewModel() { ButtonName = "MenuBtn3", ButtonText = "Cash Limit:" });
            }
            else
            {
                Buttons.Add(new MenuButtonViewModel() { ButtonName = "MenuBtn3",
                    ButtonText = "Cash Limit: "+ IoC.Transaction.Buy.PlanningToInsertEuro + " €" });
            }
            Buttons.Add(new MenuButtonViewModel() { ButtonName = "MenuBtn4", ButtonText  = "Insert cash"});

            IoC.Transaction.PropertyChanged += Transaction_PropertyChanged;


        }
        private void Transaction_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
           
        }
        public override void Initialize(Type ownerType)
        {
            if (ownerType == typeof(BuyChooseTheCurrencyViewModel))
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
            else if (ownerType == typeof(BuyDestinationAddressViewModel))
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
            else if (ownerType == typeof(BuyCashLimitViewModel))
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
            else if (ownerType == typeof(BuyInsertCashViewModel))
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
            else if (ownerType == typeof(BuyProcessingTransactionViewModel))
            {
                foreach (var btnStep in Buttons)
                {
                    btnStep.ButtonBackgound = ValidMenuImage;
                    btnStep.TextForeColor = InActiveForeground;
                }
            }
        }
    }
}