using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] stageList;
    [SerializeField]
    private GameObject[] activators;

    private int levelStage = -1;
    

    public void ActivateNextStage()
    {
        levelStage += 1;
        activators[levelStage].SetActive(false);
        stageList[levelStage].SetActive(true);
        activators[levelStage + 1].SetActive(true);
    }
}
