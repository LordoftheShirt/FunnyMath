using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MovingBox : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI numberDisplay;
    public GameObject highlight;

    private Transform conveyorEnd;
    private int firstNumber, secondNumber, result;


    // we're probably going to want to move this into conveyor mommy later, and have this controlled by an animation curve
    public float speed = 2;
    void Awake()
    {
        conveyorEnd = transform.parent;

        firstNumber = Random.Range(1, 11);
        secondNumber = Random.Range(1, 11);
        result = firstNumber * secondNumber;

        numberDisplay.text = firstNumber + " x " + secondNumber;
        gameObject.name = result.ToString();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector2(transform.position.x, conveyorEnd.position.y), GameManager.baseConveyorSpeed);
        if (transform.position.y <= conveyorEnd.position.y)
        {
            // reached end.
            Destroy(gameObject);
        }
    }
}