using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerWheelController : MonoBehaviour
{

    [SerializeField] private GameObject flickSelectToggleImage;
    [SerializeField] private TextMeshProUGUI numberDisplay, clearAnimation;
    [SerializeField] public Color[] colors;
    [SerializeField] private Image[] buttons;

    public bool playerPaired = false;
    private string inputText = "";
    private int colorLerpSpeed = 4;
    private TextMeshProUGUI tempAnimationText;

    public int myAnswer;

    // Start is called before the first frame update
    void Awake()
    {
        // Added post mortem.
        gameObject.SetActive(false);
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
            RegisterDisplayText();
        }


        /* out date FAIL and STUN mechanic
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

    private void RegisterDisplayText()
    {
        if (numberDisplay.text.Length > 0)
        {
            if (int.TryParse(numberDisplay.text, out int answer))
            {
                myAnswer = answer;
            }
        }
    }

    public void ResetAnswer()
    {
        PlayNumberClearAnimation();

        inputText = "";
        myAnswer = 0;
        MatchDisplay();
    }

    private void PlayNumberClearAnimation()
    {

        tempAnimationText = Instantiate(clearAnimation, numberDisplay.transform.position, Quaternion.identity, numberDisplay.transform);
        tempAnimationText.text = numberDisplay.text;
        tempAnimationText.color = colors[2];
    }

    public void ToggleAutoSelectDisplay()
    {
        if (flickSelectToggleImage.activeSelf) 
        flickSelectToggleImage.SetActive(false);
        else flickSelectToggleImage.SetActive(true);
    }
}
