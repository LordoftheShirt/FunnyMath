using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class SnakeMovement : MonoBehaviour
{
    [SerializeField] private Transform triangle, triangleAnchor;
    [SerializeField] private float moveSpeed = 0.1f;

    private float constrainedDistanceLength = 1;



    Vector2 swipeDirection;

    Vector2 snakeFaceDirection;

    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        snakeFaceDirection = transform.up;

        transform.position += transform.up * moveSpeed;

        transform.up = snakeFaceDirection;

        triangle.position = new Vector2(triangleAnchor.position.x + swipeDirection.x * constrainedDistanceLength, triangleAnchor.position.y + swipeDirection.y * constrainedDistanceLength);
        triangle.up = swipeDirection;


        // HÖGER PLUS 1
        // UP PLUS 1
    }

    public void SwipeInput(InputAction.CallbackContext ctx) => swipeDirection = ctx.ReadValue<Vector2>();

    private void PairSwipeAngle()
    {
        if(triangle.transform.eulerAngles.z < 45 || triangle.transform.eulerAngles.z > 315)
        {
            transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 0, transform.rotation.w);
        }
        else if(triangle.transform.eulerAngles.z < 315 && triangle.transform.eulerAngles.z > 225)
        {
            transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 270, transform.rotation.w);
        }
        else if (triangle.transform.eulerAngles.z < 225 && triangle.transform.eulerAngles.z > 135)
        {
            transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 180, transform.rotation.w);
        }
        else if (triangle.transform.eulerAngles.z < 135 && triangle.transform.eulerAngles.z > 45)
        {
            transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 90, transform.rotation.w);
        }
    }
}
