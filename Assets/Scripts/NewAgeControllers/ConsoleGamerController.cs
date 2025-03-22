using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ConsoleGamerController", menuName = "InputController/ConsoleGamerController")]
public class ConsoleGamerController : InputController
{
    private GamerWheelAnimation player;
    private int previousFocusNumber;
    public override bool RetrieveNum0Input() { if (GeneralNumInput(0)) { return true; } else { return false; } }

    public override bool RetrieveNum1Input() { if (GeneralNumInput(1)) { return true; } else { return false; } }
    public override bool RetrieveNum2Input() { if (GeneralNumInput(2)) { return true; } else { return false; } }
    public override bool RetrieveNum3Input() { if (GeneralNumInput(3)) { return true; } else { return false; } }
    public override bool RetrieveNum4Input() { if (GeneralNumInput(4)) { return true; } else { return false; } }
    public override bool RetrieveNum5Input() { if (GeneralNumInput(5)) { return true; } else { return false; } }
    public override bool RetrieveNum6Input() { if (GeneralNumInput(6)) { return true; } else { return false; } }
    public override bool RetrieveNum7Input() { if (GeneralNumInput(7)) { return true; } else { return false; } }
    public override bool RetrieveNum8Input() { if (GeneralNumInput(8)) { return true; } else { return false; } }
    public override bool RetrieveNum9Input() { if (GeneralNumInput(9)) { return true; } else { return false; } }

    public override bool RetrieveBackspace() { return false; }
    public override bool RetrieveSelectionFreeze() { return false; }

    private bool GeneralNumInput(int num)
    {
        if (player != null)
        {
            if (player.GetFocusNumber() == num && player.GetFocusNumber() != previousFocusNumber)
            {
                previousFocusNumber = player.GetFocusNumber();
                player.RecordedNumberReset();
                return true;
            }
        }
        return false;
    }

    public override void SetPlayer(GamerWheelAnimation script)
    {
        player = script;
    }
}
