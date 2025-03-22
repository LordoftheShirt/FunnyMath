using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIConveyor : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI numberDisplay;
    public GameObject highlight;

    private Transform conveyorEnd;
    private int firstNumber, secondNumber, result;

    // we're probably going to want to move this into conveyor mommy later, and have this controlled by an animation curve
    public float speed = 2;
    void Start()
    {
        conveyorEnd = transform.parent;

        firstNumber = Random.Range(1, 11);
        secondNumber = Random.Range(1, 11);
        result = firstNumber * secondNumber;

        numberDisplay.text = firstNumber + " x " + secondNumber;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector2(transform.position.x, conveyorEnd.position.y), speed);
        if (transform.position.y <= conveyorEnd.position.y)
        {
            Destroy(gameObject);
        }
    }

    public int GetResult()
    {
        return result;
    }
}
