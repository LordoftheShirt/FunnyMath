using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Transform conveyorMother;
    private UIConveyor bottomChild;
    private int boxResult, digitCount, myResult;

    [SerializeField] private InputController input = null;
    [SerializeField] private TextMeshProUGUI numberDisplay;
    [SerializeField] private float stunTime = 3f;

    private string inputText;
    private bool allowInput = true;
    private float stunCounter;
    void Start()
    {
        inputText = string.Empty;
        MatchDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        CheckBottomChild();

        if (allowInput) 
        { 
            PlayerInput();
        }
        else
        {
            // STUNS the player, then resets input. Display reset comes directly after.
            stunCounter = stunCounter - Time.deltaTime;
            if (stunCounter < 0)
            {
                allowInput = true;
                inputText = string.Empty;
                numberDisplay.color = Color.white;
                print("STUN OVER!");

            }
        }

        MatchDisplay();
    }

    public void MatchDisplay()
    {
        if (numberDisplay.text != inputText)
        {
            numberDisplay.text = inputText;
        }

        if (bottomChild != null && numberDisplay.text.Length >= digitCount)
        {
            int.TryParse(inputText, out myResult);
            if (myResult == boxResult)
            {
                Destroy(bottomChild.gameObject);
                inputText = string.Empty;
                MatchDisplay();
                print("KILL!");
            }
            else if (allowInput)
            {
                stunCounter = stunTime;
                allowInput = false;
                numberDisplay.color = Color.red;
                print("FAIL!");
            }
        }
    }

    private void PlayerInput()
    {
        if (input.RetrieveNum0Input()) inputText += 0;
        if (input.RetrieveNum1Input()) inputText += 1;
        if (input.RetrieveNum2Input()) inputText += 2;
        if (input.RetrieveNum3Input()) inputText += 3;
        if (input.RetrieveNum4Input()) inputText += 4;
        if (input.RetrieveNum5Input()) inputText += 5;
        if (input.RetrieveNum6Input()) inputText += 6;
        if (input.RetrieveNum7Input()) inputText += 7;
        if (input.RetrieveNum8Input()) inputText += 8;
        if (input.RetrieveNum9Input()) inputText += 9;
        if (input.RetrieveSelectionFreeze()) { }
        if (input.RetrieveBackspace())
        {
            if (inputText.Length > 0)
            {
               inputText = inputText.Substring(0, inputText.Length - 1);
            }
        } 

        //if (input.RetrieveLeft()) print("Left");
        //if (input.RetrieveRight()) print("Right");
    }

    private void CheckBottomChild()
    {
        if (bottomChild == null && conveyorMother.childCount > 0)
        {
            if (conveyorMother.GetChild(0).TryGetComponent<UIConveyor>(out UIConveyor uiConveyor))
            {
                bottomChild = uiConveyor;
                boxResult = bottomChild.GetResult();
                digitCount = (int)Mathf.Floor(Mathf.Log10(boxResult) + 1);
                print("DIGIT AMOUNT: " + digitCount);
                bottomChild.highlight.SetActive(true);
                bottomChild.gameObject.name = "Selected Box";
            }
        }
    }
}
