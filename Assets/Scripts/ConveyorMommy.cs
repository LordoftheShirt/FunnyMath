using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class ConveyorMommy : MonoBehaviour
{
    [SerializeField] private Color unbiasedDeletion;
    [SerializeField] private float horizontalOffset = 5f;
    [SerializeField] private float verticalOffset = 10f;
    [SerializeField] private GameObject child;
    [SerializeField] private Transform conveyorStart;

    [SerializeField] public AnimationCurve[] speedBehaviour;

    [SerializeField] private bool goCrazy = false;

    private ConveyorLine[] conveyorParents;

    private RectTransform childSize;
    private int activeConveyors = 0;
    private int[] playerAnswers;

    private GameManager gameManager;
    private GameObject tempDeathAnimation;

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
    }

    private void Update()
    {
        
    }

    void FixedUpdate()
    {
        for (int i = 0; activeConveyors > i; i++) 
        {
            ConveyorAction(i);
        }



        // All this used to be in update.
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

                for (int y = 0; gameManager.answerRegistry.Length > y; y++)
                {
                    if (gameManager.answerRegistry[y] == SiblingResult(i, j))
                    {
                        gameManager.totalSumCleared += SiblingResult(i, j);
                        gameManager.totalBoxesCleared++;

                        BoxDeathAnimation(i, j, y);

                        Destroy(conveyorParents[i].transform.GetChild(j).gameObject);
                        gameManager.playerCount[y].ResetAnswer();
                        break;
                    }
                }
            }
        }
    }

    private void CheckOnlyBottomSiblings()
    {
        for (int i = 0; i < activeConveyors; i++)
        {
            ActivateBoxHighlight(i, 0);

            for (int j = 0; gameManager.answerRegistry.Length > j; j++)
            {
                if (gameManager.answerRegistry[j] == SiblingResult(i, 0))
                {
                    gameManager.totalSumCleared += SiblingResult(i, 0);
                    gameManager.totalBoxesCleared++;

                    BoxDeathAnimation(i, 0, j);

                    Destroy(conveyorParents[i].transform.GetChild(0).gameObject);
                    gameManager.playerCount[j].ResetAnswer();
                    break;
                }
            }

        }
    }

    private void ActivateBoxHighlight(int conveyorIndex, int siblingIndex)
    {
        // Highlight gameObject must always be second sibling.
        conveyorParents[conveyorIndex].transform.GetChild(siblingIndex).transform.GetChild(1).gameObject.SetActive(true);
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

    private void BoxDeathAnimation(int conveyorIndex, int siblingIndex, int playerIndex)
    {
        tempDeathAnimation = Instantiate(child, conveyorParents[conveyorIndex].transform.GetChild(siblingIndex).position, Quaternion.identity, gameObject.transform.parent.parent);

        tempDeathAnimation.transform.GetChild(0).GetComponent<Image>().color = gameManager.playerCount[playerIndex].colors[1];

        tempDeathAnimation.AddComponent<BoxDeath>();
    }

    public void AddConveyor()
    {
        // will enable box spawns upon the next right conveyor.
        if (activeConveyors < transform.childCount)
        {
            print("Conveyor Added. From: " + activeConveyors + " to " + (activeConveyors + 1));
            activeConveyors++;
        }
        else
        {
            print("Conveyor Max Reached: " + activeConveyors);
        }
    }

    public void RemoveConveyor()
    {
        // Lowering the activeConveyor number actually only stops the continued spawn of boxes on that conveyor.
        if (activeConveyors > 0)
        {
            print("Conveyor Removed. From: " + activeConveyors + " to " + (activeConveyors-1));
            activeConveyors--;
        }
        else
        {
            print("Conveyor minimum reached: " + activeConveyors);
        }
    }

    public void ExplodeConveyor()
    {
        int conveyorIndex = activeConveyors - 1;

        RemoveConveyor();

        if (conveyorIndex == activeConveyors)
        {
            for (int i = 0; i < conveyorParents[conveyorIndex].transform.childCount; i++)
            {
                tempDeathAnimation = Instantiate(child, conveyorParents[conveyorIndex].transform.GetChild(i).position, Quaternion.identity, gameObject.transform.parent.parent);

                tempDeathAnimation.transform.GetChild(0).GetComponent<Image>().color = unbiasedDeletion;

                tempDeathAnimation.AddComponent<BoxDeath>();

                Destroy(conveyorParents[conveyorIndex].transform.GetChild(i).gameObject);
            }
        }
    }
}


