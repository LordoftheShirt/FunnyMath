using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerWheelController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI numberDisplay;
    [SerializeField] private Color[] colors;
    [SerializeField] private Image[] buttons;

    public bool playerPaired = false;
    private string inputText = "";
    private int colorLerpSpeed = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for (int i = 0; i < buttons.Length; i++) 
        {
            if (buttons[i].color != colors[0])
            {
                buttons[i].color = Color.LerpUnclamped(buttons[i].color, colors[0], colorLerpSpeed * Time.deltaTime);
            }
        }
    }

    public void ChangeButtonColor(int buttonNumber, int colorIndex)
    {
        buttons[buttonNumber].color = colors[colorIndex];
    }

    public void MatchDisplay()
    {
        if (numberDisplay.text != inputText)
        {
            numberDisplay.text = inputText;
        }


        /*
        if (bottomChild != null && numberDisplay.text.Length >= digitCount)
        {
            int.TryParse(inputText, out myResult);
            if (myResult == boxResult)
            {
                Destroy(bottomChild.gameObject);
                inputText = string.Empty;
                MatchDisplay();
                //print("KILL!");
            }
            else if (allowInput)
            {
                stunCounter = stunTime;
                allowInput = false;
                numberDisplay.color = Color.red;
                //print("FAIL!");
            }
        }*/
    }

    public void AddDigit(int newDigit)
    {
        inputText += newDigit;
        MatchDisplay();
    }

    public void RemoveDigit()
    {
        if (inputText.Length > 0)
        {
            inputText = inputText.Substring(0, inputText.Length - 1);
        }
        MatchDisplay();
    }
}
