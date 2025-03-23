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
    private int[] playerAnswers;

    private bool goCrazy = false;

    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

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

        Debug.Log("Active Conveyors: "  + activeConveyors);
    }

    private void Update()
    {
        UpdateAnswerRegistry();

        if (goCrazy)
        {
            TryEverything();
        }
        else
        {
            CheckOnlyBottomSiblings();
        }
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

    private void TryEverything()
    {
        // This scans literally the entire galaxy to find a result which matches with your answer.
        for (int i = 0; i < activeConveyors; i++)
        {
            for (int j = 0; j < conveyorParents[i].transform.childCount; j++)
            {
                foreach (int answer in gameManager.answerRegistry)
                {
                    if (answer == SiblingResult(i, j))
                    {
                        Destroy(conveyorParents[i].transform.GetChild(j));
                        break;
                    }
                }
            }
        }
    }

    private void CheckOnlyBottomSiblings()
    {
        Debug.Log("Answer Registry Length: " + gameManager.answerRegistry.Length);
        for (int i = 0; i < activeConveyors; i++)
        {
            for (int j = 0; gameManager.answerRegistry.Length > 0; j++)
            {
                Debug.Log("J:" +j + " I: " + i);
                if (gameManager.answerRegistry[j] == SiblingResult(i, 0))
                {
                    Destroy(conveyorParents[i].transform.GetChild(0));
                    gameManager.playerCount[j].ResetAnswer();
                    break;
                }
            }

        }
        // gets bottom siblings and stores them in an array, then matches with answers.

        // NOTE: DIGIT AMOUNT ALLOWED IS ITS OWN VARIABLE WHICH ONE MANUALLY INCREASES (STARTING AT 2 VARIABLES ALLOWED IF NOT THIRD IS AN ANSWER IN AND OF ITSELF.)
    }


    private void UpdateAnswerRegistry()
    {
        for (int i = 0; i < gameManager.playerCount.Length; i++)
        {
            if (gameManager.playerCount[i].playerPaired)
            {
                if (gameManager.answerRegistry[i] != gameManager.playerCount[i].myAnswer)
                {
                    gameManager.answerRegistry[i] = gameManager.playerCount[i].myAnswer;

                }
            }
        }
    }
}
