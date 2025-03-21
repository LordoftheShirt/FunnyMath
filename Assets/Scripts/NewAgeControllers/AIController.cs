using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AIController", menuName = "InputController/AIController")]

public class AIController : InputController
{
    public override bool RetrieveNum0Input()
    {
        return true;
    }

    public override bool RetrieveNum1Input() { return true; }
    public override bool RetrieveNum2Input() { return true; }
    public override bool RetrieveNum3Input() { return true; }
    public override bool RetrieveNum4Input() { return true; }
    public override bool RetrieveNum5Input() { return true; }
    public override bool RetrieveNum6Input() { return true; }
    public override bool RetrieveNum7Input() { return true; }
    public override bool RetrieveNum8Input() { return true; }
    public override bool RetrieveNum9Input() { return true; }

    public override bool RetrieveBackspace() { return true; }
    public override bool RetrieveSelectionFreeze() { return true; }
}
