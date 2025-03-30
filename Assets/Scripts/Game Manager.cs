using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthCounter, sumCounter, boxCounter;

    [SerializeField] public ConveyorMommy conveyorManager;
    [SerializeField] public PlayerWheelController[] playerCount;

    private static int health = 3;
    public static float baseConveyorSpeed = 0.6f;
    private float rememberStartSpeed;

    private AudioManager audioManager;

    [System.NonSerialized] public int[] answerRegistry;

    public static bool lostHealth = false;

    [System.NonSerialized] public int totalSumCleared = 0;
    [System.NonSerialized] public int totalBoxesCleared = 0;

    private static float immunityTimer = 3;
    private static float immunityCounter;

    private void Awake()
    {
        rememberStartSpeed = baseConveyorSpeed;
        answerRegistry = new int[playerCount.Length];
        immunityCounter = immunityTimer;
        audioManager = AudioManager.instance;
    }

    private void Start()
    {
        audioManager.Play("BattleBlockTheme");
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        if (healthCounter.text != health.ToString())
        {
            healthCounter.text = health.ToString();
        }

        if (sumCounter.text != totalSumCleared.ToString())
        {
            sumCounter.text = totalSumCleared.ToString();
        }

        if (boxCounter.text != totalBoxesCleared.ToString())
        {
            boxCounter.text = totalBoxesCleared.ToString();
        }


        if (lostHealth)
        {
            immunityCounter = immunityCounter - Time.deltaTime;
        }

        if (immunityCounter < 0)
        {
            baseConveyorSpeed = rememberStartSpeed;
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
