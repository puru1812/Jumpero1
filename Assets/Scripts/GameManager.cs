using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public Player player;
    int score = 0;
    public TMP_Text scoreLabel;
    public GameObject GameStart;
    public GameObject GameEnd;

    public GameObject Controls;
    public static GameManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    public void StartGame()
    {
        Controls.SetActive(true);
        GameStart.SetActive(false);
        player.SetAlive(true);
        score = 0;
    }
    public void AddScore(int s=0)
    {
        
        score = score+s;
    }
    public void GameOver()
    {
        GameEnd.SetActive(true);
        Controls.SetActive(false);
        scoreLabel.text = "Score: " + score;
        player.SetAlive(false);
    }
    public void ReloadLevel()
    {
        GameEnd.SetActive(false);
        StartGame();
    }
}