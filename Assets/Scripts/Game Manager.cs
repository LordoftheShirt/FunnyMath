using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthCounter, sumCounter;

    [SerializeField] public ConveyorMommy conveyorManager;
    [SerializeField] public PlayerWheelController[] playerCount;

    private static int health = 3;
    public static float baseConveyorSpeed = 1f;
    public int[] answerRegistry;

    public static bool lostHealth = false;

    public int totalSumCleared = 0;

    private static float immunityTimer = 3;
    private static float immunityCounter;

    void Awake()
    {
        answerRegistry = new int[playerCount.Length];
        immunityCounter = immunityTimer;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (healthCounter.text != health.ToString())
        {
            healthCounter.text = health.ToString();
        }

        if (sumCounter.text != totalSumCleared.ToString())
        {
            sumCounter.text = totalSumCleared.ToString();
        }


        if (lostHealth)
        {
            immunityCounter = immunityCounter - Time.deltaTime;
        }

        if (immunityCounter < 0)
        {
            baseConveyorSpeed = 1f;
            lostHealth = false;
            immunityCounter = immunityTimer;
        }
    }

    public static void HealthLoss()
    {
        lostHealth = true;
        baseConveyorSpeed = -4f;
        health--;
    }
}
