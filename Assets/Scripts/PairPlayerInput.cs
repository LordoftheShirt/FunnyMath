using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PairPlayerInput : MonoBehaviour
{
    [SerializeField] private Transform triangleLeft, triangleRight;
    [SerializeField] private float constrainedDistanceLength = 20;

    private GameManager gameManager;
    private PlayerWheelController playerWheelController;

    private Vector2 rightStickMovementInput, leftStickMovementInput;
    private Vector3 triangleLeftAnchor, triangleRightAnchor;

    private bool newLeftNumber = false, newRightNumber = false;
    private int leftHighlight, rightHighlight;
    void Awake()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        for (int i = 0; i < gameManager.playerCount.Length; i++)
        {
            if (!gameManager.playerCount[i].playerPaired)
            {
                playerWheelController = gameManager.playerCount[i];
                transform.SetParent(playerWheelController.transform.parent);
                playerWheelController.playerPaired = true;
                break;
            }
        }

        if (playerWheelController == null)
        {
            print("Pairable wheel was never found for " + gameObject.name);
            Destroy(gameObject);
        }
        else 
        {
            // It is important that 1-5 Wheel is child index 0, and that 6-0 is index 1. Parent being: Wheel Collection.
            triangleLeftAnchor = playerWheelController.transform.GetChild(0).transform.position;
            triangleRightAnchor = playerWheelController.transform.GetChild(1).transform.position;
        }
    }

    void Update()
    {
        // Left Joystick
        if (leftStickMovementInput.magnitude != 0)
        {
            triangleLeft.position = new Vector2(triangleLeftAnchor.x + leftStickMovementInput.x * constrainedDistanceLength, triangleLeftAnchor.y + leftStickMovementInput.y * constrainedDistanceLength);
            triangleLeft.up = leftStickMovementInput;

            FindWhichButtonHighlight(triangleLeft);
        }
        else if (newLeftNumber)
        {
            newLeftNumber = false;
            playerWheelController.AddDigit(leftHighlight);
            playerWheelController.ChangeButtonColor(leftHighlight, 2);
        }

        // Right Joystick
        if (rightStickMovementInput.magnitude != 0)
        {
            triangleRight.position = new Vector2(triangleRightAnchor.x + rightStickMovementInput.x * constrainedDistanceLength, triangleRightAnchor.y + rightStickMovementInput.y * constrainedDistanceLength);
            triangleRight.up = rightStickMovementInput;

            FindWhichButtonHighlight(triangleRight);
        }
        else if (newRightNumber)
        {
            newRightNumber = false;
            playerWheelController.AddDigit(rightHighlight);
            playerWheelController.ChangeButtonColor(rightHighlight, 2);
        }

    }

    public void RightJoyStick(InputAction.CallbackContext ctx) => rightStickMovementInput = ctx.ReadValue<Vector2>();

    public void LeftJoyStick(InputAction.CallbackContext ctx1) => leftStickMovementInput = ctx1.ReadValue<Vector2>();

    public void RemoveDigit(InputAction.CallbackContext context)
    {
        if (context.started) 
        {
            playerWheelController.RemoveDigit();
        }
    }

    private void FindWhichButtonHighlight(Transform insertTriangle)
    {
        if (insertTriangle.transform.localEulerAngles.z > 108 && insertTriangle.transform.eulerAngles.z < 180)
        {
            if (triangleLeft == insertTriangle)
            {
                playerWheelController.ChangeButtonColor(1, 1);
                leftHighlight = 1;
                newLeftNumber = true;
            }
            else
            {
                playerWheelController.ChangeButtonColor(6, 1);
                rightHighlight = 6;
                newRightNumber = true;
            }
        } else if (insertTriangle.transform.localEulerAngles.z > 36 && insertTriangle.transform.eulerAngles.z < 108)
        {
            if (triangleLeft == insertTriangle)
            {
                playerWheelController.ChangeButtonColor(2, 1);
                leftHighlight = 2;
                newLeftNumber = true;
            }
            else
            {
                playerWheelController.ChangeButtonColor(7, 1);
                rightHighlight = 7;
                newRightNumber = true;
            }

        } else if (insertTriangle.transform.localEulerAngles.z < 36 || insertTriangle.transform.eulerAngles.z > 324)
        {
            if (triangleLeft == insertTriangle)
            {
                playerWheelController.ChangeButtonColor(3, 1);
                leftHighlight = 3;
                newLeftNumber = true;
            }
            else
            {
                playerWheelController.ChangeButtonColor(8, 1);
                rightHighlight = 8;
                newRightNumber = true;
            }
        } else if (insertTriangle.transform.localEulerAngles.z < 324 && insertTriangle.transform.eulerAngles.z > 252)
        {
            if (triangleLeft == insertTriangle)
            {
                playerWheelController.ChangeButtonColor(4, 1);
                leftHighlight = 4;
                newLeftNumber = true;
            }
            else
            {
                playerWheelController.ChangeButtonColor(9, 1);
                rightHighlight = 9;
                newRightNumber = true;
            }
        } else if (insertTriangle.transform.localEulerAngles.z < 252 && insertTriangle.transform.eulerAngles.z > 180)
        {
            if (triangleLeft == insertTriangle)
            {
                playerWheelController.ChangeButtonColor(5, 1);
                leftHighlight = 5;
                newLeftNumber = true;
            }
            else
            {
                playerWheelController.ChangeButtonColor(0, 1);
                rightHighlight = 0;
                newRightNumber = true;
            }
        }
    }


}
