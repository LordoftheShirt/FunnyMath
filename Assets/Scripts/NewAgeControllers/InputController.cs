using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputController : ScriptableObject
{
    public abstract bool RetrieveNum0Input();
    public abstract bool RetrieveNum1Input();
    public abstract bool RetrieveNum2Input();
    public abstract bool RetrieveNum3Input();
    public abstract bool RetrieveNum4Input();
    public abstract bool RetrieveNum5Input();
    public abstract bool RetrieveNum6Input();
    public abstract bool RetrieveNum7Input();
    public abstract bool RetrieveNum8Input();
    public abstract bool RetrieveNum9Input();
    public abstract bool RetrieveBackspace();
    public abstract bool RetrieveSelectionFreeze();

}
