using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SmallCubeController : MonoBehaviour
{
    [SerializeField] private Transform cube, triangle;
    [SerializeField] private float constrainedDistanceLength = 20;
    [SerializeField] private float cubeSpeed = 100;

    private Vector3 triangleStart, outOfBoundsCheck, constrainedDistanceVector;
    private Vector2 rightStickMovementInput, leftStickMovementInput, getInputAmount;
    private GameObject myWheel;

    private void Awake()
    {
        transform.SetParent(GameObject.Find("Gamer Wheel Canvas").transform);
        myWheel = GameObject.FindWithTag("GamerWheel1");
        if(myWheel.activeSelf)
        {
            myWheel.SetActive(true);
            triangleStart = myWheel.transform.position;
            myWheel.GetComponent<GamerWheelAnimation>().myPlayer = GetComponent<SmallCubeController>();
        }
        cube.position = transform.parent.position;
        print("SPAWNED PLAYER: " + gameObject.name);
    }

    private void Update()
    {

        if (rightStickMovementInput.magnitude > 0)
        {
            triangle.position = new Vector2(triangleStart.x + rightStickMovementInput.x * constrainedDistanceLength, triangleStart.y + rightStickMovementInput.y * constrainedDistanceLength);
            triangle.up = rightStickMovementInput;
            getInputAmount = rightStickMovementInput;
        }
        else
        {
            triangle.position = new Vector2(triangleStart.x + leftStickMovementInput.x * constrainedDistanceLength, triangleStart.y + leftStickMovementInput.y * constrainedDistanceLength);
            triangle.up = leftStickMovementInput;
            getInputAmount = leftStickMovementInput;
        }
    }

    private void FixedUpdate()
    {
        cube.Translate(new Vector2(rightStickMovementInput.x, rightStickMovementInput.y) * cubeSpeed * Time.deltaTime);
    }

    public void OnMove(InputAction.CallbackContext ctx) => rightStickMovementInput = ctx.ReadValue<Vector2>();

    public void LookWithArrow(InputAction.CallbackContext ctx1) => leftStickMovementInput = ctx1.ReadValue<Vector2>();

    public float GetAngle()
    {
        return triangle.localEulerAngles.z;
    }

    public Vector2 GetJoyInput()
    {

        return getInputAmount;
    }
}
