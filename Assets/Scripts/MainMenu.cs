using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject MainUI, LevelUI;
    public void Play()
    {
        MainUI.SetActive(false);
        LevelUI.SetActive(true);
    }
    public void Setting()
    {
        Debug.Log("Setting Menu");
    }
    public void AboutUs()
    {
        Debug.Log("Myself Gauraang");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
