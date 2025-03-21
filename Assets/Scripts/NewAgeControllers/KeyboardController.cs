using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="KeyboardController", menuName ="InputController/KeyboardController")]

public class KeyboardController : InputController
{
    public override bool RetrieveNum0Input()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0)) return true;

        return Input.GetKeyDown(KeyCode.Alpha0);
    }

    public override bool RetrieveNum1Input()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1)) return true;

        return Input.GetKeyDown(KeyCode.Alpha1);
    }

    public override bool RetrieveNum2Input()
    {
        if (Input.GetKeyDown(KeyCode.Keypad2)) return true;

        return Input.GetKeyDown(KeyCode.Alpha2);
    }

    public override bool RetrieveNum3Input()
    {
        if (Input.GetKeyDown(KeyCode.Keypad3)) return true;

        return Input.GetKeyDown(KeyCode.Alpha3);
    }

    public override bool RetrieveNum4Input()
    {
        if (Input.GetKeyDown(KeyCode.Keypad4)) return true;

        return Input.GetKeyDown(KeyCode.Alpha4);
    }

    public override bool RetrieveNum5Input()
    {
        if (Input.GetKeyDown(KeyCode.Keypad5)) return true;

        return Input.GetKeyDown(KeyCode.Alpha5);
    }

    public override bool RetrieveNum6Input()
    {
        if (Input.GetKeyDown(KeyCode.Keypad6)) return true;

        return Input.GetKeyDown(KeyCode.Alpha6);
    }

    public override bool RetrieveNum7Input()
    {
        if (Input.GetKeyDown(KeyCode.Keypad7)) return true;

        return Input.GetKeyDown(KeyCode.Alpha7);
    }

    public override bool RetrieveNum8Input()
    {
        if (Input.GetKeyDown(KeyCode.Keypad8)) return true;

        return Input.GetKeyDown(KeyCode.Alpha8);
    }

    public override bool RetrieveNum9Input()
    {
        if (Input.GetKeyDown(KeyCode.Keypad9)) return true;

        return Input.GetKeyDown(KeyCode.Alpha9);
    }

    public override bool RetrieveBackspace()
    {
        // this key works. Sub optimal.
        return Input.GetKeyDown(KeyCode.Backspace);
    }

    public override bool RetrieveSelectionFreeze()
    {
        // I think of no appropriate key for this thing.
        return Input.GetKeyDown(KeyCode.KeypadPlus);
    }

}
