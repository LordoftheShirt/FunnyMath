using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamerWheelAnimation : MonoBehaviour
{
    public InputManager inputManager;
    public SmallCubeController myPlayer;

    private Image[] childAnimations;
    private int childCounter = 0;
    private int focusNumber = 0, focusNumberRecorded = 69;

    [SerializeField] private Color[] colors;
    void Start()
    {
        childAnimations = new Image[10];
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).name.Length == 1)
            {
                childAnimations[childCounter] = transform.GetChild(i).GetComponent<Image>();
                childCounter++;
            }
        }

        inputManager.input.SetPlayer(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (myPlayer != null)
        {
            if(myPlayer.GetAngle() < 360 && myPlayer.GetAngle() > 324)
            {
                childAnimations[5].color = colors[1];
                focusNumber = 5;
            }
            else if (myPlayer.GetAngle() < 324 && myPlayer.GetAngle() > 288)
            {
                childAnimations[6].color = colors[1];
                focusNumber = 6;
            }
            else if (myPlayer.GetAngle() < 288 && myPlayer.GetAngle() > 252)
            {
                childAnimations[7].color = colors[1];
                focusNumber = 7;
            }
            else if (myPlayer.GetAngle() < 252 && myPlayer.GetAngle() > 216)
            {
                childAnimations[8].color = colors[1];
                focusNumber = 8;
            }
            else if (myPlayer.GetAngle() < 216 && myPlayer.GetAngle() > 180)
            {
                childAnimations[9].color = colors[1];
                focusNumber = 9;
            }
            else if (myPlayer.GetAngle() < 180 && myPlayer.GetAngle() > 144)
            {
                childAnimations[0].color = colors[1];
                focusNumber = 0;
            }
            else if (myPlayer.GetAngle() < 144 && myPlayer.GetAngle() > 108)
            {
                childAnimations[1].color = colors[1];
                focusNumber = 1;
            }
            else if (myPlayer.GetAngle() < 108 && myPlayer.GetAngle() > 72)
            {
                childAnimations[2].color = colors[1];
                focusNumber = 2;
            }
            else if (myPlayer.GetAngle() < 72 && myPlayer.GetAngle() > 36)
            {
                childAnimations[3].color = colors[1];
                focusNumber = 3;
            }
            else if (myPlayer.GetAngle() < 36 && myPlayer.GetAngle() > 0)
            {
                childAnimations[4].color = colors[1];
                focusNumber = 4;
            }

            for (int i = 0; i < childAnimations.Length; i++)
            {
                if (i != focusNumber)
                {
                    if (childAnimations[i].color != colors[0])
                    {
                        childAnimations[i].color = colors[0];
                    }
                }
            }

            if (myPlayer.GetJoyInput().magnitude == 0 && focusNumber != 69)
            {
                if (childAnimations[focusNumber].color != colors[0])
                {
                    childAnimations[focusNumber].color = colors[0];
                    // save the result here of the last selected number.
                    
                    focusNumberRecorded = focusNumber;
                    focusNumber = 69;
                }
            }
        }
    }

    public int GetFocusNumber() { return focusNumberRecorded; }

    public void RecordedNumberReset()
    {
        focusNumberRecorded = 69;
    }
}
