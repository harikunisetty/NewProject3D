using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : Menu<GameMenu>
{
    [Header("Score")]
    [SerializeField] Text scoreText;

    public static GameMenu instance;

    public void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(this.gameObject);
            return;
        }
        else
            instance = this;
    }

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
