using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MovingBox : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI numberDisplay;
    [SerializeField] private int boxTypeIndex = 0;
    public GameObject highlight;

    private Transform conveyorEnd;
    public int firstNumber, secondNumber; 
    private int result, health;

    private ConveyorLine myConveyor;
    private float speedModifierCopy = 1;


    // we're probably going to want to move this into conveyor mommy later, and have this controlled by an animation curve
    public float speed = 2;
    void Awake()
    {
        if (transform.parent.TryGetComponent<ConveyorLine>(out ConveyorLine myParent))
        {
            myConveyor = myParent;

        }

        conveyorEnd = transform.parent;

        // Laying the ground work for multiple box types.
        DetermineBoxType();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (myConveyor != null)
        {
            speedModifierCopy = myConveyor.conveyorSpeedModifier;
        }

        transform.position = Vector3.MoveTowards(transform.position, new Vector2(transform.position.x, conveyorEnd.position.y), GameManager.baseConveyorSpeed + speedModifierCopy);
        if (transform.position.y <= conveyorEnd.position.y)
        {
            // reached end.
            GameManager.HealthLoss();
            Destroy(gameObject);
        }
    }


    private void Update()
    {
        if (gameObject.name == "CLEARED")
        {
            health--;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                GenerateTimesEquation(1, 11, 1, 11);
            }
        }
    }


    private void GenerateTimesEquation(int firstMinInlcusive, int firstMaxExclusive, int secondMinInclusive, int secondMaxExclusive)
    {
        firstNumber = Random.Range(firstMinInlcusive, firstMaxExclusive);
        secondNumber = Random.Range(secondMinInclusive, secondMaxExclusive);
        result = firstNumber * secondNumber;

        numberDisplay.text = firstNumber + " x " + secondNumber;
        gameObject.name = result.ToString();
    }

    private void DetermineBoxType()
    {
        // boxTypeIndexex explained: 0 is ordinary box. 1 is a red mega multiplcation box. 2 is a blue plus multiclear box.
        switch (boxTypeIndex)
        {
            case 0:
                GenerateTimesEquation(1, 21, 1, 21);
                health = 1;
                break;
            case 1:
                GenerateTimesEquation(1, 31, 1, 31);
                health = 1;
                break;
            case 2:
                GenerateTimesEquation(1, 11, 1, 11);
                health = 3;
                break;
        }
    }
}