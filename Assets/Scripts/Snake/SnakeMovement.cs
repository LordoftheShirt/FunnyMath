using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class SnakeMovement : MonoBehaviour
{
    Vector2 swipeDirection;

    Vector2 snakeFaceDirection;
    [SerializeField] private float moveSpeed = 0.1f;
    
    void Start()
    {
        print(transform.up);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        snakeFaceDirection = transform.up;

        transform.position += transform.up * moveSpeed;

        transform.up = snakeFaceDirection;

    }

    public void SwipeInput(InputAction.CallbackContext ctx) => swipeDirection = ctx.ReadValue<Vector2>();
}
