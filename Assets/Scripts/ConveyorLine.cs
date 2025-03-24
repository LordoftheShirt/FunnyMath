using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;

public class ConveyorLine : MonoBehaviour
{

    public bool conveyorOn = false;
    [SerializeField] public AnimationCurve[] speedBehaviour;
    public float conveyorSpeedModifier;

    private void Awake()
    {
        conveyorSpeedModifier = Random.Range(0.8f, 1.2f);
    }
}
