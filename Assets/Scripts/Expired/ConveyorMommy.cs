using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorMommy : MonoBehaviour
{
    [SerializeField] private float horizontalOffset = 5f;
    [SerializeField] private float verticalOffset = 10f;
    [SerializeField] private GameObject child;
    [SerializeField] private Transform conveyorStart;
    private ConveyorLine[] conveyorParents;

    private RectTransform childSize;
    private int activeConveyors = 0;

    void Start()
    {
        childSize = child.GetComponent<RectTransform>();
        conveyorParents = new ConveyorLine[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            conveyorParents[i] = transform.GetChild(i).GetComponent<ConveyorLine>();
            activeConveyors++;
        }


    }

    void FixedUpdate()
    {
        for (int i = 0; activeConveyors > i; i++) 
        {
            ConveyorAction(i);
        }
    }

    public void ConveyorAction(int index)
    {
        if (conveyorParents[index].transform.childCount == 0)
        {
            Instantiate(child, new Vector3(conveyorStart.position.x + (childSize.sizeDelta.x + horizontalOffset) * index, conveyorStart.position.y), Quaternion.identity, conveyorParents[index].transform);
        }

        if (conveyorParents[index].transform.GetChild(conveyorParents[index].transform.childCount - 1).position.y < (conveyorStart.position.y - childSize.sizeDelta.y - verticalOffset))
        {
            Instantiate(child, new Vector3(conveyorStart.position.x + (childSize.sizeDelta.x + horizontalOffset) * index, conveyorStart.position.y), Quaternion.identity, conveyorParents[index].transform);

        }
    }

    private void MeasureDeltaDistance()
    {

    }
}
