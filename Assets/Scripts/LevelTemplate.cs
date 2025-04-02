using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTemplate : MonoBehaviour
{

    // what more ?!
    [Header("Level Attributes")]
    public int levelIndex;
    public int baseSpeed;
    public int specialBoxSpawnRate;

    public int boxDifficulty;

    [Header("Conveyor eccentricities")]
    public float verticalOffset;
    public float behaviourAmplifier;

}
