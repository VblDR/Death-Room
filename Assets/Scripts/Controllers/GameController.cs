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
    
    //UI
    [SerializeField]
    private GameObject finishGame;

    private int levelStage = -1;

    private void Start()
    {
        instance = this;
    }


    public static void ActivateNextStage()
    {
        instance.levelStage += 1;
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
        Player.GameFinished();
        finishGame.SetActive(true);
        if (SceneManager.GetActiveScene().buildIndex - 1 == PlayerPrefs.GetInt("CurrentLevel"))
            PlayerPrefs.SetInt("CurrentLevel", PlayerPrefs.GetInt("CurrentLevel") + 1);
    }

    public static void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene("Level" + PlayerPrefs.GetInt("CurrentLevel"));
    }
}
