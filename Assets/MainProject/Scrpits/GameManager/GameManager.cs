using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Player")]
    [SerializeField] GameObject player;
    [SerializeField] Player_Movement playerController;
    [SerializeField] float pHealth;
    private float maxPlayerHealth = 100;
    public float PlayerHealth { get => pHealth; }
    public GameObject Player { get { return player; } }

    [Header("Player Score")]
    [SerializeField] int score = 0;
    public int Score { get => score; }

    [Header("Levels")]
    [SerializeField] int nextLevelIndex;
    [SerializeField] string nextLevelName;
    [SerializeField] LevelObject levelObjective;

    [Header("Game")]
    private bool isGameOver;
    public bool IsGameOver { get => isGameOver; }


    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(this.gameObject);
            return;
        }
        else
            Instance = this;

        // DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "MainUI")
            return;
        // Player Setup
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<Player_Movement>();

        levelObjective = Object.FindObjectOfType<LevelObject>();

        pHealth = maxPlayerHealth;

        isGameOver = false;

        // Validate Data
        PlayerScore(PlayerPrefs.GetInt("PlayerScore"));

        Debug.Log(PlayerPrefs.GetInt("PlayerScore"));
    }

    void Update()
    {
        if (levelObjective != null && levelObjective.IsObjectiveCompleted)
        {
            LevelEnded();
        }
    }

    public void PlayerDamage(float value)
    {
        if (PlayerHealth > 0f)
        {
            pHealth -= value;

            if (PlayerHealth <= 0f)
                PlayerDead();
        }
        else
        {
            PlayerDead();
        }
    }

    public void PlayerScore(int value)
    {
        score += value; // Variable value

       UiManager.Instance.UpdateScoreUI(); // UI

        // Save Playe Score Data
        PlayerPrefs.SetInt("PlayerScore", Score);

        Debug.Log(PlayerPrefs.GetInt("PlayerScore"));
    }

    public void PlayerDead()
    {
        isGameOver = true;

        // Save Game State
        // Kill the player
        // Move Game Over Screen
    }

    void LevelEnded()
    {
        if (playerController != null)
        {
            // Disable player controll
            playerController.enabled = false;

            // Stop Movement
            player.GetComponent<CharacterController>().SimpleMove(Vector3.zero);

            // Load Next level
            // LoadNextLevel(nextLevelName);
            LoadNextLevel();
        }
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextLevel()
    {
        // Get next level build index
        int nextLevelIndex = (SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings;

        LoadNextLevel(nextLevelIndex);
    }
    public void LoadNextLevel(int index)
    {
        if (index > 0 && index <= SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(index);
        }
    }

    public void LoadNextLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


    public void GameOver()
    {
        // Clear Game Data
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
}
