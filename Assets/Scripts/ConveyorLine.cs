using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;

public class ConveyorLine : MonoBehaviour
{
    public bool conveyorOn = false;
    public float conveyorSpeedModifier;

    private void Awake()
    {
        conveyorSpeedModifier = Random.Range(-0.2f, 0.2f);
    }
}
