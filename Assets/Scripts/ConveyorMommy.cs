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
    private int[] firstSiblingResults;

    void Start()
    {
        childSize = child.GetComponent<RectTransform>();
        conveyorParents = new ConveyorLine[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            conveyorParents[i] = transform.GetChild(i).GetComponent<ConveyorLine>();
            if (conveyorParents[i].conveyorOn)
            {
                activeConveyors++;
            }
        }

        firstSiblingResults = new int[activeConveyors];
    }

    private void Update()
    { 
        // This scans literally the entire galaxy to find a result which matches with your answer.
        /*
        for (int i = 0; i < activeConveyors; i++) 
        {
            for (int j = 0; j < conveyorParents[i].transform.childCount; j++)
            {
                // if My Answer equals any of these children
                if (5 == SiblingResult(i, j))
                {
                    Destroy(conveyorParents[i].transform.GetChild(j));
                }
            }
        } */
    }

    void FixedUpdate()
    {
        for (int i = 0; activeConveyors > i; i++) 
        {
            ConveyorAction(i);
        }
    }

    private void ConveyorAction(int index)
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

    private int SiblingResult(int conveyorIndex, int siblingIndex)
    {
        if (int.TryParse(conveyorParents[conveyorIndex].transform.GetChild(siblingIndex).name, out int result))
        {
            return result;
        }
        else
        {
            print(conveyorParents[conveyorIndex].transform.GetChild(siblingIndex).name + " is fucked.");
            return 69;
        }
    }
}
