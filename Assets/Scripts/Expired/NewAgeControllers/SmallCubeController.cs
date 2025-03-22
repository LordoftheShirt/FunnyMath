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
    private SceneManager sceneManager;

    private void Awake()
    {
        transform.SetParent(GameObject.Find("Gamer Wheel Canvas").transform);

        if(!SceneManager.playerCount[0].activeSelf)
        {
            SpawnPlayer(0);
        }
        else if (!SceneManager.playerCount[1].activeSelf)
        {
            SpawnPlayer(1);
        }
        else if (!SceneManager.playerCount[2].activeSelf)
        {
            SpawnPlayer(2);
        }
        else if (!SceneManager.playerCount[3].activeSelf)
        {
            SpawnPlayer(3);
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

    private void SpawnPlayer(int index)
    {
        myWheel = SceneManager.playerCount[index];
        myWheel.SetActive(true);
        triangleStart = myWheel.transform.position;
        myWheel.GetComponent<GamerWheelAnimation>().myPlayer = GetComponent<SmallCubeController>();
    }
}
