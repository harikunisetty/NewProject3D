using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : Menu<GameMenu>
{
    [Header("Score")]
    [SerializeField] Text scoreText;

    public void Start()
    {
        scoreText.text = "Score: " + GameManager.Instance.Score.ToString();
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        PauseMenuPrefab.Open();
    }

    public void UpdateScoreUI()
    {
        scoreText.text = "Score: " + GameManager.Instance.Score.ToString();
    }
}
