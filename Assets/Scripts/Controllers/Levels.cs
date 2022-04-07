using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Levels : MonoBehaviour
{

    [SerializeField]
    private GameObject levelButtonsHolder;

    private void Start()
    {
        int i = 0;
        foreach(Button button in levelButtonsHolder.GetComponentsInChildren<Button>())
        {
            if (i < PlayerPrefs.GetInt("CurrentLevel"))
                button.interactable = true;
            else
                break;
            i++;
        }
    }

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene("Level" + level);
    }


    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
