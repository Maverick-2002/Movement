
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab.ClientModels;
using TMPro;
using PlayFab;
using UnityEngine.UI;
using UnityEditor;
[System.Serializable]

public class PlayerProgress : MonoBehaviour
{
    public int CurrentMissionID = 5;
    public int LastMissionID = 1;
    public int totalplaytime = 1;
    public int Score;
    public BallSpawner ball;
    public Text badText;
    public Text goodText;
    public Text levelText;

    public void Update()
    {
        UpdateUI();
    }
    public void DummyData()
    {
        totalplaytime = 1;
        CurrentMissionID = 5;
        LastMissionID = 1;
      //  ball.playerScore = 0;
      //  ball.playerLives = 0;
    }
    void UpdateUI()
    {
        if (goodText != null && badText != null && levelText != null)
        {
            goodText.text = "Good Item Picked: " + totalplaytime.ToString();
            badText.text = "Bad Item Picked:" + CurrentMissionID.ToString();
            levelText.text = "Level: " + LastMissionID.ToString();
        }
    }
}