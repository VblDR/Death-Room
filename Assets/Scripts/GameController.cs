using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    private static GameController instance;

    [SerializeField]
    private GameObject[] stageList;
    [SerializeField]
    private GameObject[] activators;

    private int levelStage = -1;

    private void Start()
    {
        instance = this;
    }


    public static void ActivateNextStage()
    {
        instance.levelStage += 1;
        instance.activators[instance.levelStage].SetActive(false);
        if (instance.levelStage + 1 != instance.activators.Length)
        {
            instance.stageList[instance.levelStage].SetActive(true);
            instance.activators[instance.levelStage + 1].SetActive(true);
        }
        else
            instance.FinishLevel();
    }

    private void FinishLevel()
    {
        Debug.Log("Level Finished!");
    }

    public static void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
