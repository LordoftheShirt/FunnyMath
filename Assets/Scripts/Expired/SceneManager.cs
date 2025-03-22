using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public static int sharedHealth = 3;
    public static GameObject[] playerCount = new GameObject[4];
    public static int[] currentResults;

    void Awake()
    {
        playerCount[0] = GameObject.FindWithTag("GamerWheel1");
        playerCount[1] = GameObject.FindWithTag("GamerWheel2");
        playerCount[2] = GameObject.FindWithTag("GamerWheel3");
        playerCount[3] = GameObject.FindWithTag("GamerWheel4");

        playerCount[0].SetActive(false);
        if (playerCount[1] != null)
            playerCount[1].SetActive(false);
        if (playerCount[2] != null)
            playerCount[2].SetActive(false);
        if (playerCount[3] != null)
            playerCount[3].SetActive(false);
    }
    void Update()
    {
        
    }
}
