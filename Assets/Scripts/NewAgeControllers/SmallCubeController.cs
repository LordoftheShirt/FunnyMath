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
    private Vector2 rightStickMovementInput, leftStickMovementInput;
    private LineRenderer lineRenderer;

    private void Awake()
    {
        transform.SetParent(GameObject.Find("Gamer Wheel Canvas").transform);
        triangleStart = GameObject.FindWithTag("GamerWheel1").transform.position;
        cube.position = transform.parent.position;
        print("SPAWNED PLAYER: " + gameObject.name);
    }

    private void Update()
    {
        //lineRenderer.SetPosition(0, triangleStart);

        if (rightStickMovementInput.magnitude > 0)
        {
            triangle.position = new Vector2(triangleStart.x + rightStickMovementInput.x * constrainedDistanceLength, triangleStart.y + rightStickMovementInput.y * constrainedDistanceLength);
            triangle.up = rightStickMovementInput;
        }
        else
        {
            triangle.position = new Vector2(triangleStart.x + leftStickMovementInput.x * constrainedDistanceLength, triangleStart.y + leftStickMovementInput.y * constrainedDistanceLength);
            triangle.up = leftStickMovementInput;
        }

    }

    private void FixedUpdate()
    {
        cube.Translate(new Vector2(rightStickMovementInput.x, rightStickMovementInput.y) * cubeSpeed * Time.deltaTime);

        //print(leftStickMovementInput);
    }

    public void OnMove(InputAction.CallbackContext ctx) => rightStickMovementInput = ctx.ReadValue<Vector2>();

    public void LookWithArrow(InputAction.CallbackContext ctx1) => leftStickMovementInput = ctx1.ReadValue<Vector2>();
}
