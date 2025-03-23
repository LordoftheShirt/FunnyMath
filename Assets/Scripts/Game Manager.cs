using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public PlayerWheelController[] playerCount;
    //private static int health = 3;
    //private static float conveyorSpeed = 2;
    public int[] answerRegistry;

    private int totalSumCleared;

    void Awake()
    {
        answerRegistry = new int[playerCount.Length];
    }

    // Update is called once per frame
    void Update()
    {

          
    }
}
