using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public PlayerWheelController[] playerCount;
    //private static int health = 3;
    public static float baseConveyorSpeed = 1f;
    public int[] answerRegistry;

    public int totalSumCleared;

    void Awake()
    {
        answerRegistry = new int[playerCount.Length];
    }

    // Update is called once per frame
    void Update()
    {

          
    }
}
