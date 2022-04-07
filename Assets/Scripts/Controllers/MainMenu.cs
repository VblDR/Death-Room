using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{

    [SerializeField]
    private Color soundOn, soundOff;
    [SerializeField]
    private Image soundSprite;
    private bool sound = true;


    private void Start()
    {
        CheckPlayerPrefs();
    }


    private void CheckPlayerPrefs()
    {
        if (PlayerPrefs.HasKey("Sound"))
        {
            sound = PlayerPrefs.GetInt("Sound") == 1 ? true : false;
        }
        else
        {
            PlayerPrefs.SetInt("Sound", 1);
            PlayerPrefs.SetInt("CurrentLevel", 1);
        }
    }

    public void StartLevel()
    {
        SceneManager.LoadScene("Level" + PlayerPrefs.GetInt("CurrentLevel"));
    }

    public void SwitchSound()
    {
        if(sound)
        {
            soundSprite.color = soundOff;
            AudioListener.volume = 0;
            AudioListener.pause = false;
        }
        else
        {
            soundSprite.color = soundOn;
            AudioListener.volume = 1;
            AudioListener.pause = false;
        }
        sound = !sound;
    }

    public void OpenLevels()
    {
        SceneManager.LoadScene("Levels");
    }
}
