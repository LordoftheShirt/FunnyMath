using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorMommy : MonoBehaviour
{
    [SerializeField] private float distance = 10f;
    [SerializeField] private GameObject child;
    [SerializeField] private Transform conveyorStart;

    private RectTransform childSize;

    void Start()
    {
        childSize = child.GetComponent<RectTransform>();
        print(childSize.sizeDelta.y);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.childCount == 0)
        {
            Instantiate(child, conveyorStart.position, Quaternion.identity, transform);
        }
        
        if (transform.GetChild(transform.childCount -1).position.y < (conveyorStart.position.y - childSize.sizeDelta.y - distance))
        {
            Instantiate(child, conveyorStart.position, Quaternion.identity, transform);
        }
    }
}
