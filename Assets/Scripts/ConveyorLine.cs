using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;

public class ConveyorLine : MonoBehaviour
{
    public bool conveyorOn = false;
    public float conveyorSpeedModifier;
    private float timeTracker = 0;

    private int myAnimationCurve;
    private float amplitude = 0.5f;

    private ConveyorMommy conveyorManager;

    private float doNothingNumber;

    private void Awake()
    {
        // here it chooses right from the start which speed behavior (animation curve) to adhere to.
        conveyorManager = transform.parent.GetComponent<ConveyorMommy>();
        myAnimationCurve = Random.Range(0, conveyorManager.speedBehaviour.Length);

        // timeTracker will start somewhere between x = 0 and x = 10 on the graph.
        //timeTracker = Random.Range(0, 10);

        // this below is an outdated approach. 
        //conveyorSpeedModifier = Random.Range(-0.2f, 0.2f);
    }

    private void FixedUpdate()
    {
        timeTracker += Time.deltaTime;

        //doNothingNumber = conveyorManager.speedBehaviour[myAnimationCurve].Evaluate(timeTracker) * amplitude;

        //print(doNothingNumber);

        conveyorSpeedModifier = conveyorManager.speedBehaviour[myAnimationCurve].Evaluate(timeTracker) * amplitude;
    }
}
