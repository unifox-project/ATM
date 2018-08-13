using System;

namespace CRYPTOMAT
{
    class RedeemStepMenuViewModel : StepMenuViewModel
    {
        public RedeemStepMenuViewModel()
        {
            LabelTitleText = "The final step to sell\nyour сrypto-currency";

            Buttons.Add(new MenuButtonViewModel() { ButtonName = "MenuBtn1", ButtonText = "Send"});
            Buttons.Add(new MenuButtonViewModel() { ButtonName = "MenuBtn1", ButtonText = "Wait a few minutes"  });
            Buttons.Add(new MenuButtonViewModel() { ButtonName = "MenuBtn3", ButtonText = "Scan redeem ticket" });
            Buttons.Add(new MenuButtonViewModel() { ButtonName = "MenuBtn4", ButtonText = "Take out the money" });
        }
        public override void Initialize(Type ownerType)
        {
            if (ownerType == typeof(RedeemTicketViewModel))
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
            else
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